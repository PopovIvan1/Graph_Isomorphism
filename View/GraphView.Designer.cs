namespace View
{
    partial class GraphView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.myFirstGraphPictureBox = new System.Windows.Forms.PictureBox();
            this.mySecondGraphPictureBox = new System.Windows.Forms.PictureBox();
            this.myAnswerTextBox = new System.Windows.Forms.RichTextBox();
            this.myFirstGraphBotton = new System.Windows.Forms.Button();
            this.mySecondGraphBotton = new System.Windows.Forms.Button();
            this.myAnswerBotton = new System.Windows.Forms.Button();
            this.myAnswerLabel = new System.Windows.Forms.Label();
            this.myIsomorphismLabel = new System.Windows.Forms.Label();
            this.myTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.myFirstGraphPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mySecondGraphPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // myFirstGraphPictureBox
            // 
            this.myFirstGraphPictureBox.Location = new System.Drawing.Point(0, 0);
            this.myFirstGraphPictureBox.Name = "myFirstGraphPictureBox";
            this.myFirstGraphPictureBox.Size = new System.Drawing.Size(400, 400);
            this.myFirstGraphPictureBox.TabIndex = 0;
            this.myFirstGraphPictureBox.TabStop = false;
            // 
            // mySecondGraphPictureBox
            // 
            this.mySecondGraphPictureBox.Location = new System.Drawing.Point(440, 0);
            this.mySecondGraphPictureBox.Name = "mySecondGraphPictureBox";
            this.mySecondGraphPictureBox.Size = new System.Drawing.Size(400, 400);
            this.mySecondGraphPictureBox.TabIndex = 1;
            this.mySecondGraphPictureBox.TabStop = false;
            // 
            // myAnswerTextBox
            // 
            this.myAnswerTextBox.Location = new System.Drawing.Point(1113, 66);
            this.myAnswerTextBox.Name = "myAnswerTextBox";
            this.myAnswerTextBox.Size = new System.Drawing.Size(97, 94);
            this.myAnswerTextBox.TabIndex = 17;
            this.myAnswerTextBox.Text = "";
            // 
            // myFirstGraphBotton
            // 
            this.myFirstGraphBotton.Location = new System.Drawing.Point(859, 12);
            this.myFirstGraphBotton.Name = "myFirstGraphBotton";
            this.myFirstGraphBotton.Size = new System.Drawing.Size(112, 51);
            this.myFirstGraphBotton.TabIndex = 18;
            this.myFirstGraphBotton.Text = "Upload first graph";
            this.myFirstGraphBotton.UseVisualStyleBackColor = true;
            // 
            // mySecondGraphBotton
            // 
            this.mySecondGraphBotton.Location = new System.Drawing.Point(859, 78);
            this.mySecondGraphBotton.Name = "mySecondGraphBotton";
            this.mySecondGraphBotton.Size = new System.Drawing.Size(112, 51);
            this.mySecondGraphBotton.TabIndex = 19;
            this.mySecondGraphBotton.Text = "Upload second graph";
            this.mySecondGraphBotton.UseVisualStyleBackColor = true;
            // 
            // myAnswerBotton
            // 
            this.myAnswerBotton.Location = new System.Drawing.Point(859, 152);
            this.myAnswerBotton.Name = "myAnswerBotton";
            this.myAnswerBotton.Size = new System.Drawing.Size(112, 51);
            this.myAnswerBotton.TabIndex = 20;
            this.myAnswerBotton.Text = "Get answer";
            this.myAnswerBotton.UseVisualStyleBackColor = true;
            // 
            // myAnswerLabel
            // 
            this.myAnswerLabel.AutoSize = true;
            this.myAnswerLabel.Location = new System.Drawing.Point(1056, 46);
            this.myAnswerLabel.Name = "myAnswerLabel";
            this.myAnswerLabel.Size = new System.Drawing.Size(58, 17);
            this.myAnswerLabel.TabIndex = 21;
            this.myAnswerLabel.Text = "Answer:";
            // 
            // myIsomorphismLabel
            // 
            this.myIsomorphismLabel.AutoSize = true;
            this.myIsomorphismLabel.Location = new System.Drawing.Point(1016, 69);
            this.myIsomorphismLabel.Name = "myIsomorphismLabel";
            this.myIsomorphismLabel.Size = new System.Drawing.Size(91, 17);
            this.myIsomorphismLabel.TabIndex = 22;
            this.myIsomorphismLabel.Text = "Isomorphism:";
            // 
            // myTimeLabel
            // 
            this.myTimeLabel.AutoSize = true;
            this.myTimeLabel.Location = new System.Drawing.Point(1016, 229);
            this.myTimeLabel.Name = "myTimeLabel";
            this.myTimeLabel.Size = new System.Drawing.Size(43, 17);
            this.myTimeLabel.TabIndex = 23;
            this.myTimeLabel.Text = "Time:";
            // 
            // GraphView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 450);
            this.Controls.Add(this.myTimeLabel);
            this.Controls.Add(this.myIsomorphismLabel);
            this.Controls.Add(this.myAnswerLabel);
            this.Controls.Add(this.myAnswerBotton);
            this.Controls.Add(this.mySecondGraphBotton);
            this.Controls.Add(this.myFirstGraphBotton);
            this.Controls.Add(this.myAnswerTextBox);
            this.Controls.Add(this.mySecondGraphPictureBox);
            this.Controls.Add(this.myFirstGraphPictureBox);
            this.Name = "GraphView";
            ((System.ComponentModel.ISupportInitialize)(this.myFirstGraphPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mySecondGraphPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox myFirstGraphPictureBox;
        private System.Windows.Forms.PictureBox mySecondGraphPictureBox;
        private System.Windows.Forms.RichTextBox myAnswerTextBox;
        private System.Windows.Forms.Button myFirstGraphBotton;
        private System.Windows.Forms.Button mySecondGraphBotton;
        private System.Windows.Forms.Button myAnswerBotton;
        private System.Windows.Forms.Label myAnswerLabel;
        private System.Windows.Forms.Label myIsomorphismLabel;
        private System.Windows.Forms.Label myTimeLabel;
    }
}

