namespace MahtabStore
{
    partial class About
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel = new DevComponents.DotNetBar.PanelEx();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.From = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.To = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.Title = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Subject = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Send = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PassCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.CanvasColor = System.Drawing.SystemColors.Control;
            this.Panel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Panel.DisabledBackColor = System.Drawing.Color.Empty;
            this.Panel.Font = new System.Drawing.Font("MRT_Mitra_3", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Panel.Location = new System.Drawing.Point(24, 298);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(733, 111);
            this.Panel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.Panel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.Panel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(4)))), ((int)(((byte)(41)))));
            this.Panel.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine;
            this.Panel.Style.BorderColor.Color = System.Drawing.Color.White;
            this.Panel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.Panel.Style.ForeColor.Color = System.Drawing.Color.White;
            this.Panel.Style.GradientAngle = 90;
            this.Panel.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MahtabStore.Properties.Resources.Global_Network_icon;
            this.pictureBox3.Location = new System.Drawing.Point(520, 38);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(200, 200);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MahtabStore.Properties.Resources.Mail_at_icon;
            this.pictureBox2.Location = new System.Drawing.Point(290, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MahtabStore.Properties.Resources.logo_ig_stunning_instagram_logo_vector_download_for_new_7;
            this.pictureBox1.Location = new System.Drawing.Point(60, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // From
            // 
            // 
            // 
            // 
            this.From.Border.Class = "TextBoxBorder";
            this.From.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.From.Font = new System.Drawing.Font("IRDavat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.From.Location = new System.Drawing.Point(389, 473);
            this.From.MaxLength = 50;
            this.From.Name = "From";
            this.From.PreventEnterBeep = true;
            this.From.Size = new System.Drawing.Size(321, 32);
            this.From.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(716, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "از :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(716, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "به :";
            // 
            // To
            // 
            // 
            // 
            // 
            this.To.Border.Class = "TextBoxBorder";
            this.To.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.To.Font = new System.Drawing.Font("IRDavat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.To.Location = new System.Drawing.Point(389, 549);
            this.To.MaxLength = 50;
            this.To.Name = "To";
            this.To.PreventEnterBeep = true;
            this.To.Size = new System.Drawing.Size(321, 32);
            this.To.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(716, 589);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "عنوان :";
            // 
            // Title
            // 
            // 
            // 
            // 
            this.Title.Border.Class = "TextBoxBorder";
            this.Title.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Title.Font = new System.Drawing.Font("IRDavat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Title.Location = new System.Drawing.Point(389, 587);
            this.Title.MaxLength = 50;
            this.Title.Name = "Title";
            this.Title.PreventEnterBeep = true;
            this.Title.Size = new System.Drawing.Size(321, 32);
            this.Title.TabIndex = 3;
            // 
            // Subject
            // 
            // 
            // 
            // 
            this.Subject.Border.Class = "TextBoxBorder";
            this.Subject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Subject.Font = new System.Drawing.Font("IRDavat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Subject.Location = new System.Drawing.Point(153, 473);
            this.Subject.Multiline = true;
            this.Subject.Name = "Subject";
            this.Subject.PreventEnterBeep = true;
            this.Subject.Size = new System.Drawing.Size(230, 146);
            this.Subject.TabIndex = 4;
            this.Subject.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Subject.WatermarkText = "موضوع";
            // 
            // Send
            // 
            this.Send.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Send.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.Send.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Send.ForeColor = System.Drawing.Color.White;
            this.Send.Location = new System.Drawing.Point(17, 539);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(108, 31);
            this.Send.TabIndex = 5;
            this.Send.Text = "فرستادن";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(716, 513);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "رمز :";
            // 
            // PassCode
            // 
            // 
            // 
            // 
            this.PassCode.Border.Class = "TextBoxBorder";
            this.PassCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PassCode.Font = new System.Drawing.Font("IRDavat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PassCode.Location = new System.Drawing.Point(389, 511);
            this.PassCode.MaxLength = 50;
            this.PassCode.Name = "PassCode";
            this.PassCode.PreventEnterBeep = true;
            this.PassCode.Size = new System.Drawing.Size(321, 32);
            this.PassCode.TabIndex = 1;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PassCode);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.Subject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.To);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.From);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("MRT_Mitra_3", 12F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "About";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(780, 696);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.PanelEx Panel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private DevComponents.DotNetBar.Controls.TextBoxX From;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX To;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX Title;
        private DevComponents.DotNetBar.Controls.TextBoxX Subject;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX PassCode;
    }
}
