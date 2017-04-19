namespace ScaleGraph
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GraphPicture = new System.Windows.Forms.PictureBox();
            this.AddNodeButton = new System.Windows.Forms.Button();
            this.AddEdgeButton = new System.Windows.Forms.Button();
            this.graphBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GraphPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphPicture
            // 
            this.GraphPicture.Location = new System.Drawing.Point(2, 41);
            this.GraphPicture.Name = "GraphPicture";
            this.GraphPicture.Size = new System.Drawing.Size(932, 415);
            this.GraphPicture.TabIndex = 0;
            this.GraphPicture.TabStop = false;
            // 
            // AddNodeButton
            // 
            this.AddNodeButton.Location = new System.Drawing.Point(724, 12);
            this.AddNodeButton.Name = "AddNodeButton";
            this.AddNodeButton.Size = new System.Drawing.Size(75, 23);
            this.AddNodeButton.TabIndex = 1;
            this.AddNodeButton.Text = "AddNode";
            this.AddNodeButton.UseVisualStyleBackColor = true;
            this.AddNodeButton.Click += new System.EventHandler(this.AddNodeButton_Click);
            // 
            // AddEdgeButton
            // 
            this.AddEdgeButton.Location = new System.Drawing.Point(816, 12);
            this.AddEdgeButton.Name = "AddEdgeButton";
            this.AddEdgeButton.Size = new System.Drawing.Size(75, 23);
            this.AddEdgeButton.TabIndex = 2;
            this.AddEdgeButton.Text = "AddEdge";
            this.AddEdgeButton.UseVisualStyleBackColor = true;
            this.AddEdgeButton.Click += new System.EventHandler(this.AddEdgeButton_Click);
            // 
            // graphBox
            // 
            this.graphBox.Location = new System.Drawing.Point(2, 41);
            this.graphBox.Name = "graphBox";
            this.graphBox.Size = new System.Drawing.Size(932, 415);
            this.graphBox.TabIndex = 3;
            this.graphBox.TabStop = false;
            this.graphBox.Click += new System.EventHandler(this.graphBox_Click);
            this.graphBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphBox_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 455);
            this.Controls.Add(this.graphBox);
            this.Controls.Add(this.AddEdgeButton);
            this.Controls.Add(this.AddNodeButton);
            this.Controls.Add(this.GraphPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GraphPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GraphPicture;
        private System.Windows.Forms.Button AddNodeButton;
        private System.Windows.Forms.Button AddEdgeButton;
        private System.Windows.Forms.PictureBox graphBox;
    }
}

