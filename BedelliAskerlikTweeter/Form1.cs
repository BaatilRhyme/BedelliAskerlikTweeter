using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TweetSharp;

namespace BedelliAskerlikTweeter
{
    public partial class Form1 : Form
    {
        // Pass your credentials to the service
        TwitterService service = new TwitterService("dq07QLIgmXHsT3N6otmFdiOnj", "4GAYeJWwKNl7sk6r66ptm2JdEiA1K4OsKILUnGTnzsz6D9yoIY");
        FacebookCollector face;

        OAuthRequestToken requestToken;
        private bool retweetstarted = false;
        BackgroundWorker workerReTweet = new BackgroundWorker();
        BackgroundWorker workerfaceTweet = new BackgroundWorker();
        private bool TwitterLoginSuccess = false;
        public Form1()
        {
            InitializeComponent();
            workerReTweet.DoWork += workerReTweet_DoWork;
            workerReTweet.WorkerSupportsCancellation = true;
            workerfaceTweet.DoWork += workerfaceTweet_DoWork;
            workerfaceTweet.RunWorkerCompleted += workerfaceTweet_RunWorkerCompleted;
            workerfaceTweet.WorkerSupportsCancellation = true;
            face = new FacebookCollector(service,this);
        }
        void workerfaceTweet_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            face.Stop();
            lstLog.Items.Add("Face Tweet Durdu");
            btnFacebookTweet.Text = "Facebook'da Bul ve Tweetle";
        }
        void workerfaceTweet_DoWork(object sender, DoWorkEventArgs e)
        {
            face.Start(txtFace.Text.Trim(), txtBirlestirHashTag.Text.Trim());
        }

        void workerReTweet_DoWork(object sender, DoWorkEventArgs e)
        {
            RetweetBaslat(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DogrulamaKoduAl();
        }
        private void DogrulamaKoduAl()
        {
            // Step 1 - Retrieve an OAuth Request Token
            requestToken = service.GetRequestToken();

            // Step 2 - Redirect to the OAuth Authorization URL
            Uri uri = service.GetAuthorizationUri(requestToken);
            ctlBrowserTwitter.Navigate(uri.ToString());
        }

        private void btnDogrula_Click(object sender, EventArgs e)
        {
            var verifier = txtPin.Text.Trim();
            OAuthAccessToken access = service.GetAccessToken(requestToken, verifier);

            // Step 4 - User authenticates using the Access Token
            service.AuthenticateWith(access.Token, access.TokenSecret);
            if (access.UserId > 0)
            {
                lblDurum.Text = "Başarılı.";
                lblDurum.ForeColor = Color.Green;
                TwitterLoginSuccess = true;
            }
            else
            {

                lblDurum.Text = "Başarısız!";
                lblDurum.ForeColor = Color.Red;
                TwitterLoginSuccess = false;
            }

        }

        private void btnPinKoduAl_Click(object sender, EventArgs e)
        {
            DogrulamaKoduAl();
        }

        private void btnReTweet_Click(object sender, EventArgs e)
        {
            if (!TwitterLoginSuccess)
            {
                MessageBox.Show("Twitter Pin Kodu Al!");
                return;
            }
            if (retweetstarted)
            {
                retweetstarted = false;
                lstLog.Items.Add("Retweet Durdu");
                if (workerReTweet.IsBusy)
                    workerReTweet.CancelAsync();
                btnReTweet.Text = "Girilen Hashtag İçin Retweet Başlat";
            }
            else
            {
                retweetstarted = true;
                lstLog.Items.Add("Retweet Başladı.");
                workerReTweet.RunWorkerAsync();
                btnReTweet.Text = "Durdur.";
            }
        }
        private int GetLastId(string keyword)
        {
            var filename = string.Format("{0}.bedelli", keyword);
            int id = 0;
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                var line = reader.ReadLine();
                reader.Close();
                if (string.IsNullOrEmpty(line))
                    return id;
                else
                    id = int.Parse(line);
            }
            else
            {
                File.Create(filename);
            }
            return id;

        }
        private void RetweetBaslat(DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(txtHashTag.Text.Trim()))
            {
                MessageBox.Show("Anahtar Kelime giriniz!");
                return;
            }
            var searchOptions = new SearchOptions();
            searchOptions.Count = 100;
            searchOptions.IncludeEntities = true;
            searchOptions.Q = txtHashTag.Text.Trim();
            searchOptions.SinceId = GetLastId(searchOptions.Q);
            var tweets = service.Search(searchOptions);

            while (tweets.Statuses.Count() > 0 && retweetstarted)
            {
                tweets = service.Search(searchOptions);
                var tweetsStatutes = tweets.Statuses.OrderBy(t => t.Id).ToList();
                foreach (var tweet in tweetsStatutes)
                {
                    if (!retweetstarted)
                    {
                        e.Cancel = true;
                        break;
                    }
                    var status = service.Retweet(new RetweetOptions() { Id = tweet.Id });
                    WriteLastId(searchOptions.Q, tweet.Id);
                    Log(tweet.Text);
                    System.Threading.Thread.Sleep(2000);//twitter kızmasın
                }
                searchOptions.SinceId = tweetsStatutes.Last().Id;
            }
        }
        public void Log(string log)
        {
            lstLog.Invoke(new Action(() =>
 {
     lstLog.Items.Add(log);
 }));
        }
        private void WriteLastId(string keyword, long p)
        {
            var filename = string.Format("{0}.bedelli", keyword);
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(p);
            writer.Close();
        }

        private void btnFacebookTweet_Click(object sender, EventArgs e)
        {
            if (!TwitterLoginSuccess)
            {
                MessageBox.Show("Twitter Pin Kodu Al!");
                return;
            }
            if (face.IsStarted)
            {
                face.Stop();
                lstLog.Items.Add("Face Tweet Durdu");
                if (workerfaceTweet.IsBusy)
                    workerfaceTweet.CancelAsync();
                btnFacebookTweet.Text = "Facebook'da Bul ve Tweetle";
            }
            else
            {
                lstLog.Items.Add("Face Tweet Başladı.");
                workerfaceTweet.RunWorkerAsync();
                btnFacebookTweet.Text = "Durdur.";
            }

        }
    }
}
