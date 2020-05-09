namespace YES.Forms
{
    partial class frmEnc
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
            this.txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDec = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnEnc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnother = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt.Location = new System.Drawing.Point(147, 91);
            this.txt.MaxLength = 200;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(539, 36);
            this.txt.TabIndex = 0;
            this.txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Before Text :";
            // 
            // btnDec
            // 
            this.btnDec.Location = new System.Drawing.Point(513, 144);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(173, 45);
            this.btnDec.TabIndex = 2;
            this.btnDec.Text = "Decrypt";
            this.btnDec.UseVisualStyleBackColor = true;
            this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Key :";
            // 
            // txtKey
            // 
            this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtKey.Location = new System.Drawing.Point(147, 31);
            this.txtKey.MaxLength = 200;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(539, 36);
            this.txtKey.TabIndex = 3;
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEnc
            // 
            this.btnEnc.Location = new System.Drawing.Point(147, 144);
            this.btnEnc.Name = "btnEnc";
            this.btnEnc.Size = new System.Drawing.Size(173, 45);
            this.btnEnc.TabIndex = 5;
            this.btnEnc.Text = "Encrypt";
            this.btnEnc.UseVisualStyleBackColor = true;
            this.btnEnc.Click += new System.EventHandler(this.btnEnc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "After Text :";
            // 
            // txtAnother
            // 
            this.txtAnother.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnother.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtAnother.Location = new System.Drawing.Point(147, 224);
            this.txtAnother.MaxLength = 200;
            this.txtAnother.Name = "txtAnother";
            this.txtAnother.Size = new System.Drawing.Size(539, 36);
            this.txtAnother.TabIndex = 6;
            this.txtAnother.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmEnc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 313);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAnother);
            this.Controls.Add(this.btnEnc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnDec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEnc";
            this.Text = "frmEnc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnEnc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnother;
    }
}