namespace BedelliAskerlikTweeter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPin = new System.Windows.Forms.TextBox();
            this.btnReTweet = new System.Windows.Forms.Button();
            this.ctlBrowserTwitter = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDogrula = new System.Windows.Forms.Button();
            this.txtHashTag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.btnPinKoduAl = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFace = new System.Windows.Forms.TextBox();
            this.btnFacebookTweet = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBirlestirHashTag = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPin
            // 
            this.txtPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPin.Location = new System.Drawing.Point(147, 276);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(131, 26);
            this.txtPin.TabIndex = 0;
            // 
            // btnReTweet
            // 
            this.btnReTweet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReTweet.Location = new System.Drawing.Point(17, 338);
            this.btnReTweet.Name = "btnReTweet";
            this.btnReTweet.Size = new System.Drawing.Size(406, 56);
            this.btnReTweet.TabIndex = 1;
            this.btnReTweet.Text = "Girilen Hashtag İçin Retweet Başlat";
            this.btnReTweet.UseVisualStyleBackColor = true;
            this.btnReTweet.Click += new System.EventHandler(this.btnReTweet_Click);
            // 
            // ctlBrowserTwitter
            // 
            this.ctlBrowserTwitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlBrowserTwitter.Location = new System.Drawing.Point(0, 0);
            this.ctlBrowserTwitter.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctlBrowserTwitter.Name = "ctlBrowserTwitter";
            this.ctlBrowserTwitter.Size = new System.Drawing.Size(903, 219);
            this.ctlBrowserTwitter.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(882, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Yukarıda açılan Sayfada Twitter Hesabınızı Girip Aşağıdaki Alana PIN Kodunuzu Yaz" +
    "ıp Kullanmaya Başlayınız!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "PIN Kodunuz : ";
            // 
            // btnDogrula
            // 
            this.btnDogrula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDogrula.Location = new System.Drawing.Point(299, 273);
            this.btnDogrula.Name = "btnDogrula";
            this.btnDogrula.Size = new System.Drawing.Size(124, 33);
            this.btnDogrula.TabIndex = 5;
            this.btnDogrula.Text = "Doğrula";
            this.btnDogrula.UseVisualStyleBackColor = true;
            this.btnDogrula.Click += new System.EventHandler(this.btnDogrula_Click);
            // 
            // txtHashTag
            // 
            this.txtHashTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHashTag.Location = new System.Drawing.Point(147, 308);
            this.txtHashTag.Name = "txtHashTag";
            this.txtHashTag.Size = new System.Drawing.Size(276, 26);
            this.txtHashTag.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hash Tag : ";
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurum.Location = new System.Drawing.Point(448, 279);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(0, 20);
            this.lblDurum.TabIndex = 9;
            // 
            // btnPinKoduAl
            // 
            this.btnPinKoduAl.Location = new System.Drawing.Point(744, 225);
            this.btnPinKoduAl.Name = "btnPinKoduAl";
            this.btnPinKoduAl.Size = new System.Drawing.Size(150, 23);
            this.btnPinKoduAl.TabIndex = 10;
            this.btnPinKoduAl.Text = "PIN Kodu Al";
            this.btnPinKoduAl.UseVisualStyleBackColor = true;
            this.btnPinKoduAl.Click += new System.EventHandler(this.btnPinKoduAl_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(438, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Anahtar Kelime : ";
            // 
            // txtFace
            // 
            this.txtFace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFace.Location = new System.Drawing.Point(590, 305);
            this.txtFace.Name = "txtFace";
            this.txtFace.Size = new System.Drawing.Size(276, 26);
            this.txtFace.TabIndex = 12;
            // 
            // btnFacebookTweet
            // 
            this.btnFacebookTweet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacebookTweet.Location = new System.Drawing.Point(442, 364);
            this.btnFacebookTweet.Name = "btnFacebookTweet";
            this.btnFacebookTweet.Size = new System.Drawing.Size(424, 56);
            this.btnFacebookTweet.TabIndex = 11;
            this.btnFacebookTweet.Text = "Facebook\'da Bul ve Tweetle";
            this.btnFacebookTweet.UseVisualStyleBackColor = true;
            this.btnFacebookTweet.Click += new System.EventHandler(this.btnFacebookTweet_Click);
            // 
            // lstLog
            // 
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(0, 433);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(903, 134);
            this.lstLog.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 410);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Log : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(438, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "İle Birleştirerek : ";
            // 
            // txtBirlestirHashTag
            // 
            this.txtBirlestirHashTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBirlestirHashTag.Location = new System.Drawing.Point(590, 337);
            this.txtBirlestirHashTag.Name = "txtBirlestirHashTag";
            this.txtBirlestirHashTag.Size = new System.Drawing.Size(276, 26);
            this.txtBirlestirHashTag.TabIndex = 16;
            this.txtBirlestirHashTag.Text = "#bedelliaskerlik";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 567);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBirlestirHashTag);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFace);
            this.Controls.Add(this.btnFacebookTweet);
            this.Controls.Add(this.btnPinKoduAl);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHashTag);
            this.Controls.Add(this.btnDogrula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlBrowserTwitter);
            this.Controls.Add(this.btnReTweet);
            this.Controls.Add(this.txtPin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Bedelli Askerlik Retweeter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Button btnReTweet;
        private System.Windows.Forms.WebBrowser ctlBrowserTwitter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDogrula;
        private System.Windows.Forms.TextBox txtHashTag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Button btnPinKoduAl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFace;
        private System.Windows.Forms.Button btnFacebookTweet;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBirlestirHashTag;
    }
}

