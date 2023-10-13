namespace CheckerAnime.WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            AddAnime = new Button();
            listBoxAnime = new ListBox();
            textBoxAnime = new TextBox();
            buttonAnimeRemove = new Button();
            button1 = new Button();
            listBoxVoices = new ListBox();
            textBoxVoice = new TextBox();
            buttonVoiceAdd = new Button();
            buttonVoiceRemove = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(356, 9);
            label1.Name = "label1";
            label1.Size = new Size(108, 35);
            label1.TabIndex = 0;
            label1.Text = "ANIME";
            // 
            // AddAnime
            // 
            AddAnime.Location = new Point(343, 93);
            AddAnime.Name = "AddAnime";
            AddAnime.Size = new Size(75, 23);
            AddAnime.TabIndex = 1;
            AddAnime.Text = "Добавить";
            AddAnime.UseVisualStyleBackColor = true;
            AddAnime.Click += AddAnime_Click;
            // 
            // listBoxAnime
            // 
            listBoxAnime.FormattingEnabled = true;
            listBoxAnime.ItemHeight = 15;
            listBoxAnime.Location = new Point(57, 94);
            listBoxAnime.Name = "listBoxAnime";
            listBoxAnime.Size = new Size(120, 94);
            listBoxAnime.TabIndex = 2;
            // 
            // textBoxAnime
            // 
            textBoxAnime.Location = new Point(213, 94);
            textBoxAnime.Name = "textBoxAnime";
            textBoxAnime.Size = new Size(100, 23);
            textBoxAnime.TabIndex = 3;
            // 
            // buttonAnimeRemove
            // 
            buttonAnimeRemove.Location = new Point(343, 122);
            buttonAnimeRemove.Name = "buttonAnimeRemove";
            buttonAnimeRemove.Size = new Size(75, 23);
            buttonAnimeRemove.TabIndex = 4;
            buttonAnimeRemove.Text = "Удалить";
            buttonAnimeRemove.UseVisualStyleBackColor = true;
            buttonAnimeRemove.Click += buttonAnimeRemove_Click;
            // 
            // button1
            // 
            button1.Location = new Point(702, 94);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBoxVoices
            // 
            listBoxVoices.FormattingEnabled = true;
            listBoxVoices.ItemHeight = 15;
            listBoxVoices.Location = new Point(57, 214);
            listBoxVoices.Name = "listBoxVoices";
            listBoxVoices.Size = new Size(120, 94);
            listBoxVoices.TabIndex = 6;
            // 
            // textBoxVoice
            // 
            textBoxVoice.Location = new Point(213, 214);
            textBoxVoice.Name = "textBoxVoice";
            textBoxVoice.Size = new Size(100, 23);
            textBoxVoice.TabIndex = 7;
            // 
            // buttonVoiceAdd
            // 
            buttonVoiceAdd.Location = new Point(343, 213);
            buttonVoiceAdd.Name = "buttonVoiceAdd";
            buttonVoiceAdd.Size = new Size(75, 23);
            buttonVoiceAdd.TabIndex = 8;
            buttonVoiceAdd.Text = "Добавить";
            buttonVoiceAdd.UseVisualStyleBackColor = true;
            buttonVoiceAdd.Click += buttonVoiceAdd_Click;
            // 
            // buttonVoiceRemove
            // 
            buttonVoiceRemove.Location = new Point(343, 242);
            buttonVoiceRemove.Name = "buttonVoiceRemove";
            buttonVoiceRemove.Size = new Size(75, 23);
            buttonVoiceRemove.TabIndex = 9;
            buttonVoiceRemove.Text = "Удалить";
            buttonVoiceRemove.UseVisualStyleBackColor = true;
            buttonVoiceRemove.Click += buttonVoiceRemove_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonVoiceRemove);
            Controls.Add(buttonVoiceAdd);
            Controls.Add(textBoxVoice);
            Controls.Add(listBoxVoices);
            Controls.Add(button1);
            Controls.Add(buttonAnimeRemove);
            Controls.Add(textBoxAnime);
            Controls.Add(listBoxAnime);
            Controls.Add(AddAnime);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button AddAnime;
        private ListBox listBoxAnime;
        private TextBox textBoxAnime;
        private Button buttonAnimeRemove;
        private Button button1;
        private ListBox listBoxVoices;
        private TextBox textBoxVoice;
        private Button buttonVoiceAdd;
        private Button buttonVoiceRemove;
    }
}