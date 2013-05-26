namespace Jamb
{
    partial class StartForm
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
            this.components = new System.ComponentModel.Container();
            this.cbBrP = new System.Windows.Forms.ComboBox();
            this.txtPlayer2 = new System.Windows.Forms.TextBox();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.txtPlayer1 = new System.Windows.Forms.TextBox();
            this.cbJacina = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errPlayer1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errPlayer2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errJacina = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errJacina)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBrP
            // 
            this.cbBrP.FormattingEnabled = true;
            this.cbBrP.Location = new System.Drawing.Point(126, 117);
            this.cbBrP.Name = "cbBrP";
            this.cbBrP.Size = new System.Drawing.Size(100, 21);
            this.cbBrP.TabIndex = 0;
            this.cbBrP.SelectedIndexChanged += new System.EventHandler(this.cbBrP_SelectedIndexChanged);
            // 
            // txtPlayer2
            // 
            this.txtPlayer2.Location = new System.Drawing.Point(126, 203);
            this.txtPlayer2.Name = "txtPlayer2";
            this.txtPlayer2.Size = new System.Drawing.Size(100, 20);
            this.txtPlayer2.TabIndex = 2;
            this.txtPlayer2.Visible = false;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Location = new System.Drawing.Point(63, 206);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(48, 13);
            this.lblPlayer2.TabIndex = 7;
            this.lblPlayer2.Text = "Player 2:";
            this.lblPlayer2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Број на Играчи:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Име на играч:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(268, 289);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Изгаси";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(66, 289);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(160, 23);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.Text = "Почни !";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(79, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 56);
            this.label7.TabIndex = 13;
            this.label7.Text = "Jumb";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Location = new System.Drawing.Point(63, 180);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(48, 13);
            this.lblPlayer1.TabIndex = 15;
            this.lblPlayer1.Text = "Player 1:";
            this.lblPlayer1.Visible = false;
            // 
            // txtPlayer1
            // 
            this.txtPlayer1.Location = new System.Drawing.Point(126, 177);
            this.txtPlayer1.Name = "txtPlayer1";
            this.txtPlayer1.Size = new System.Drawing.Size(100, 20);
            this.txtPlayer1.TabIndex = 14;
            this.txtPlayer1.Visible = false;
            // 
            // cbJacina
            // 
            this.cbJacina.FormattingEnabled = true;
            this.cbJacina.Location = new System.Drawing.Point(126, 90);
            this.cbJacina.Name = "cbJacina";
            this.cbJacina.Size = new System.Drawing.Size(100, 21);
            this.cbJacina.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Јачина:";
            // 
            // errPlayer1
            // 
            this.errPlayer1.ContainerControl = this;
            // 
            // errPlayer2
            // 
            this.errPlayer2.ContainerControl = this;
            // 
            // errJacina
            // 
            this.errJacina.ContainerControl = this;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 322);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbJacina);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.txtPlayer1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.txtPlayer2);
            this.Controls.Add(this.cbBrP);
            this.Name = "StartForm";
            this.Text = "Jamb";
            ((System.ComponentModel.ISupportInitialize)(this.errPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errJacina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBrP;
        private System.Windows.Forms.TextBox txtPlayer2;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.TextBox txtPlayer1;
        private System.Windows.Forms.ComboBox cbJacina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errPlayer1;
        private System.Windows.Forms.ErrorProvider errPlayer2;
        private System.Windows.Forms.ErrorProvider errJacina;
    }
}