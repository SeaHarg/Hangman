namespace prjHangman
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mtbAnswer = new System.Windows.Forms.MaskedTextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.picDrawing = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDrawing)).BeginInit();
            this.SuspendLayout();
            // 
            // mtbAnswer
            // 
            this.mtbAnswer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mtbAnswer.Enabled = false;
            this.mtbAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbAnswer.Location = new System.Drawing.Point(12, 12);
            this.mtbAnswer.Name = "mtbAnswer";
            this.mtbAnswer.PromptChar = '-';
            this.mtbAnswer.Size = new System.Drawing.Size(513, 37);
            this.mtbAnswer.TabIndex = 0;
            this.mtbAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(411, 13);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(114, 39);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(73)))), ((int)(((byte)(164)))));
            this.imageList1.Images.SetKeyName(0, "1.png");
            this.imageList1.Images.SetKeyName(1, "2.png");
            this.imageList1.Images.SetKeyName(2, "3.png");
            this.imageList1.Images.SetKeyName(3, "4.png");
            this.imageList1.Images.SetKeyName(4, "5.png");
            this.imageList1.Images.SetKeyName(5, "6.png");
            this.imageList1.Images.SetKeyName(6, "7.png");
            // 
            // picDrawing
            // 
            this.picDrawing.Location = new System.Drawing.Point(103, 36);
            this.picDrawing.Name = "picDrawing";
            this.picDrawing.Size = new System.Drawing.Size(250, 254);
            this.picDrawing.TabIndex = 2;
            this.picDrawing.TabStop = false;
            this.picDrawing.Click += new System.EventHandler(this.picDrawing_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 408);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.mtbAnswer);
            this.Controls.Add(this.picDrawing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picDrawing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtbAnswer;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox picDrawing;
    }
}

