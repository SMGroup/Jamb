namespace Jamb
{
    partial class FinishForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrv = new System.Windows.Forms.Label();
            this.lblVtor = new System.Windows.Forms.Label();
            this.lblTret = new System.Windows.Forms.Label();
            this.lblCetvrt = new System.Windows.Forms.Label();
            this.lblPobednik = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(109, 238);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Излези";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "ЧЕСТИТО !";
            // 
            // lblPrv
            // 
            this.lblPrv.AutoSize = true;
            this.lblPrv.Location = new System.Drawing.Point(15, 99);
            this.lblPrv.Name = "lblPrv";
            this.lblPrv.Size = new System.Drawing.Size(27, 13);
            this.lblPrv.TabIndex = 4;
            this.lblPrv.Text = "Прв";
            // 
            // lblVtor
            // 
            this.lblVtor.AutoSize = true;
            this.lblVtor.Location = new System.Drawing.Point(15, 132);
            this.lblVtor.Name = "lblVtor";
            this.lblVtor.Size = new System.Drawing.Size(31, 13);
            this.lblVtor.TabIndex = 5;
            this.lblVtor.Text = "Втор";
            // 
            // lblTret
            // 
            this.lblTret.AutoSize = true;
            this.lblTret.Location = new System.Drawing.Point(15, 162);
            this.lblTret.Name = "lblTret";
            this.lblTret.Size = new System.Drawing.Size(31, 13);
            this.lblTret.TabIndex = 6;
            this.lblTret.Text = "Трет";
            // 
            // lblCetvrt
            // 
            this.lblCetvrt.AutoSize = true;
            this.lblCetvrt.Location = new System.Drawing.Point(15, 191);
            this.lblCetvrt.Name = "lblCetvrt";
            this.lblCetvrt.Size = new System.Drawing.Size(43, 13);
            this.lblCetvrt.TabIndex = 7;
            this.lblCetvrt.Text = "Четврт";
            // 
            // lblPobednik
            // 
            this.lblPobednik.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPobednik.Location = new System.Drawing.Point(-1, 41);
            this.lblPobednik.Margin = new System.Windows.Forms.Padding(0);
            this.lblPobednik.Name = "lblPobednik";
            this.lblPobednik.Size = new System.Drawing.Size(290, 23);
            this.lblPobednik.TabIndex = 8;
            this.lblPobednik.Text = "Победник e";
            this.lblPobednik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FinishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.lblPobednik);
            this.Controls.Add(this.lblCetvrt);
            this.Controls.Add(this.lblTret);
            this.Controls.Add(this.lblVtor);
            this.Controls.Add(this.lblPrv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Name = "FinishForm";
            this.Text = "Резултати";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPrv;
        private System.Windows.Forms.Label lblVtor;
        private System.Windows.Forms.Label lblTret;
        private System.Windows.Forms.Label lblCetvrt;
        private System.Windows.Forms.Label lblPobednik;
    }
}