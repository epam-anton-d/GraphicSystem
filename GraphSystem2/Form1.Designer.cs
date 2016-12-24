namespace GraphSystem2
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
            this.figureChanger = new System.Windows.Forms.ListBox();
            this.cleanButton = new System.Windows.Forms.Button();
            this.actionChanger = new System.Windows.Forms.ListBox();
            this.starTops = new System.Windows.Forms.ListBox();
            this.figureColor = new System.Windows.Forms.ListBox();
            this.thickness = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // figureChanger
            // 
            this.figureChanger.FormattingEnabled = true;
            this.figureChanger.Location = new System.Drawing.Point(12, 12);
            this.figureChanger.Name = "figureChanger";
            this.figureChanger.Size = new System.Drawing.Size(136, 134);
            this.figureChanger.TabIndex = 0;
            this.figureChanger.SelectedIndexChanged += new System.EventHandler(this.figureChanger_SelectedIndexChanged);
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(13, 412);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(75, 23);
            this.cleanButton.TabIndex = 1;
            this.cleanButton.Text = "Очистить";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // actionChanger
            // 
            this.actionChanger.FormattingEnabled = true;
            this.actionChanger.Location = new System.Drawing.Point(12, 153);
            this.actionChanger.Name = "actionChanger";
            this.actionChanger.Size = new System.Drawing.Size(136, 56);
            this.actionChanger.TabIndex = 2;
            // 
            // starTops
            // 
            this.starTops.FormattingEnabled = true;
            this.starTops.Location = new System.Drawing.Point(12, 216);
            this.starTops.Name = "starTops";
            this.starTops.Size = new System.Drawing.Size(120, 69);
            this.starTops.TabIndex = 3;
            // 
            // figureColor
            // 
            this.figureColor.FormattingEnabled = true;
            this.figureColor.Location = new System.Drawing.Point(13, 292);
            this.figureColor.Name = "figureColor";
            this.figureColor.Size = new System.Drawing.Size(120, 43);
            this.figureColor.TabIndex = 4;
            this.figureColor.SelectedIndexChanged += new System.EventHandler(this.figureColor_SelectedIndexChanged);
            // 
            // thickness
            // 
            this.thickness.FormattingEnabled = true;
            this.thickness.Location = new System.Drawing.Point(13, 342);
            this.thickness.Name = "thickness";
            this.thickness.Size = new System.Drawing.Size(120, 43);
            this.thickness.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 429);
            this.Controls.Add(this.thickness);
            this.Controls.Add(this.figureColor);
            this.Controls.Add(this.starTops);
            this.Controls.Add(this.actionChanger);
            this.Controls.Add(this.cleanButton);
            this.Controls.Add(this.figureChanger);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox figureChanger;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.ListBox actionChanger;
        private System.Windows.Forms.ListBox starTops;
        private System.Windows.Forms.ListBox figureColor;
        private System.Windows.Forms.ListBox thickness;
    }
}

