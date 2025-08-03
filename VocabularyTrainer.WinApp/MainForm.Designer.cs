namespace WinApp
{
    partial class MainForm
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
			components = new System.ComponentModel.Container();
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			MainTabControl = new TabControl();
			TrainYourselfPage = new TabPage();
			DeleteWordButton = new Button();
			DisplayTranslationTextBox = new TextBox();
			ShowNextButton = new Button();
			ShowTranslationButton = new Button();
			DisplayWordTextBox = new TextBox();
			AddNewWordsPage = new TabPage();
			AddDataButton = new Button();
			EnterHereLabel = new Label();
			TranslationLabel = new Label();
			WordToLearnLabel = new Label();
			InputTranslationTextBox = new TextBox();
			InputWordTextBox = new TextBox();
			UserPage = new TabPage();
			textBox1 = new TextBox();
			CurrentUserTextBox = new TextBox();
			CurrentUserLabel = new Label();
			AddWordsErrorProvider = new ErrorProvider(components);
			MainTabControl.SuspendLayout();
			TrainYourselfPage.SuspendLayout();
			AddNewWordsPage.SuspendLayout();
			UserPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)AddWordsErrorProvider).BeginInit();
			SuspendLayout();
			// 
			// MainTabControl
			// 
			MainTabControl.Controls.Add(TrainYourselfPage);
			MainTabControl.Controls.Add(AddNewWordsPage);
			MainTabControl.Controls.Add(UserPage);
			MainTabControl.Location = new Point(2, 3);
			MainTabControl.Name = "MainTabControl";
			MainTabControl.SelectedIndex = 0;
			MainTabControl.Size = new Size(799, 363);
			MainTabControl.TabIndex = 0;
			// 
			// TrainYourselfPage
			// 
			TrainYourselfPage.BackColor = Color.Transparent;
			TrainYourselfPage.Controls.Add(DeleteWordButton);
			TrainYourselfPage.Controls.Add(DisplayTranslationTextBox);
			TrainYourselfPage.Controls.Add(ShowNextButton);
			TrainYourselfPage.Controls.Add(ShowTranslationButton);
			TrainYourselfPage.Controls.Add(DisplayWordTextBox);
			TrainYourselfPage.ForeColor = Color.Black;
			TrainYourselfPage.Location = new Point(4, 35);
			TrainYourselfPage.Name = "TrainYourselfPage";
			TrainYourselfPage.Padding = new Padding(3);
			TrainYourselfPage.Size = new Size(791, 324);
			TrainYourselfPage.TabIndex = 0;
			TrainYourselfPage.Text = "Train yourself";
			TrainYourselfPage.Enter += TrainYourSelfPageEnter;
			// 
			// DeleteWordButton
			// 
			DeleteWordButton.Location = new Point(314, 269);
			DeleteWordButton.Name = "DeleteWordButton";
			DeleteWordButton.Size = new Size(189, 42);
			DeleteWordButton.TabIndex = 4;
			DeleteWordButton.Text = "Delete";
			DeleteWordButton.UseVisualStyleBackColor = true;
			DeleteWordButton.Click += DeleteWord;
			// 
			// DisplayTranslationTextBox
			// 
			DisplayTranslationTextBox.BackColor = SystemColors.Control;
			DisplayTranslationTextBox.Font = new Font("Comic Sans MS", 20.25F);
			DisplayTranslationTextBox.Location = new Point(101, 123);
			DisplayTranslationTextBox.Name = "DisplayTranslationTextBox";
			DisplayTranslationTextBox.ReadOnly = true;
			DisplayTranslationTextBox.Size = new Size(609, 45);
			DisplayTranslationTextBox.TabIndex = 3;
			DisplayTranslationTextBox.TextAlign = HorizontalAlignment.Center;
			DisplayTranslationTextBox.KeyDown += TextBox_SwitchFocus;
			// 
			// ShowNextButton
			// 
			ShowNextButton.Location = new Point(435, 199);
			ShowNextButton.Name = "ShowNextButton";
			ShowNextButton.Size = new Size(275, 42);
			ShowNextButton.TabIndex = 2;
			ShowNextButton.Text = "I remember!";
			ShowNextButton.UseVisualStyleBackColor = true;
			ShowNextButton.Click += ShowNextWord;
			// 
			// ShowTranslationButton
			// 
			ShowTranslationButton.Location = new Point(101, 199);
			ShowTranslationButton.Name = "ShowTranslationButton";
			ShowTranslationButton.Size = new Size(275, 42);
			ShowTranslationButton.TabIndex = 1;
			ShowTranslationButton.Text = "Translation";
			ShowTranslationButton.UseVisualStyleBackColor = true;
			ShowTranslationButton.Click += ShowTranslation;
			// 
			// DisplayWordTextBox
			// 
			DisplayWordTextBox.Font = new Font("Comic Sans MS", 20.25F);
			DisplayWordTextBox.Location = new Point(101, 57);
			DisplayWordTextBox.Name = "DisplayWordTextBox";
			DisplayWordTextBox.ReadOnly = true;
			DisplayWordTextBox.Size = new Size(609, 45);
			DisplayWordTextBox.TabIndex = 0;
			DisplayWordTextBox.TextAlign = HorizontalAlignment.Center;
			DisplayWordTextBox.KeyDown += TextBox_SwitchFocus;
			// 
			// AddNewWordsPage
			// 
			AddNewWordsPage.BackColor = Color.Transparent;
			AddNewWordsPage.Controls.Add(AddDataButton);
			AddNewWordsPage.Controls.Add(EnterHereLabel);
			AddNewWordsPage.Controls.Add(TranslationLabel);
			AddNewWordsPage.Controls.Add(WordToLearnLabel);
			AddNewWordsPage.Controls.Add(InputTranslationTextBox);
			AddNewWordsPage.Controls.Add(InputWordTextBox);
			AddNewWordsPage.ForeColor = Color.Black;
			AddNewWordsPage.Location = new Point(4, 24);
			AddNewWordsPage.Name = "AddNewWordsPage";
			AddNewWordsPage.Padding = new Padding(3);
			AddNewWordsPage.Size = new Size(791, 335);
			AddNewWordsPage.TabIndex = 1;
			AddNewWordsPage.Text = "Add new words";
			// 
			// AddDataButton
			// 
			AddDataButton.BackColor = Color.Transparent;
			AddDataButton.ForeColor = Color.Black;
			AddDataButton.Location = new Point(38, 244);
			AddDataButton.Name = "AddDataButton";
			AddDataButton.Size = new Size(723, 54);
			AddDataButton.TabIndex = 7;
			AddDataButton.Text = "Add the data!";
			AddDataButton.UseVisualStyleBackColor = false;
			AddDataButton.Click += AddNewWord;
			// 
			// EnterHereLabel
			// 
			EnterHereLabel.AutoSize = true;
			EnterHereLabel.Location = new Point(6, 23);
			EnterHereLabel.Name = "EnterHereLabel";
			EnterHereLabel.Size = new Size(140, 26);
			EnterHereLabel.TabIndex = 6;
			EnterHereLabel.Text = "Enter here the";
			// 
			// TranslationLabel
			// 
			TranslationLabel.AutoSize = true;
			TranslationLabel.Location = new Point(52, 114);
			TranslationLabel.Name = "TranslationLabel";
			TranslationLabel.Size = new Size(110, 26);
			TranslationLabel.TabIndex = 4;
			TranslationLabel.Text = "Translation";
			// 
			// WordToLearnLabel
			// 
			WordToLearnLabel.AutoSize = true;
			WordToLearnLabel.Location = new Point(27, 67);
			WordToLearnLabel.Name = "WordToLearnLabel";
			WordToLearnLabel.Size = new Size(135, 26);
			WordToLearnLabel.TabIndex = 3;
			WordToLearnLabel.Text = "Word to learn";
			// 
			// InputTranslationTextBox
			// 
			InputTranslationTextBox.Location = new Point(168, 114);
			InputTranslationTextBox.Name = "InputTranslationTextBox";
			InputTranslationTextBox.Size = new Size(593, 34);
			InputTranslationTextBox.TabIndex = 1;
			InputTranslationTextBox.Tag = "translation";
			InputTranslationTextBox.TextChanged += ValidateTextBox;
			InputTranslationTextBox.KeyDown += TextBox_SwitchFocus;
			// 
			// InputWordTextBox
			// 
			InputWordTextBox.Location = new Point(168, 64);
			InputWordTextBox.Name = "InputWordTextBox";
			InputWordTextBox.Size = new Size(593, 34);
			InputWordTextBox.TabIndex = 0;
			InputWordTextBox.Tag = "word to learn";
			InputWordTextBox.TextChanged += ValidateTextBox;
			InputWordTextBox.KeyDown += TextBox_SwitchFocus;
			// 
			// UserPage
			// 
			UserPage.BackColor = Color.Transparent;
			UserPage.Controls.Add(textBox1);
			UserPage.Controls.Add(CurrentUserTextBox);
			UserPage.Controls.Add(CurrentUserLabel);
			UserPage.ForeColor = Color.Black;
			UserPage.Location = new Point(4, 24);
			UserPage.Name = "UserPage";
			UserPage.Padding = new Padding(3);
			UserPage.Size = new Size(791, 335);
			UserPage.TabIndex = 2;
			UserPage.Text = "Select user";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(6, 78);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new Size(437, 153);
			textBox1.TabIndex = 13;
			textBox1.Text = "TO IMPLEMENT:\r\n1. MULTIPLE USERS\r\n2. MULTIPLE DICTIONARIES PER USER\r\n3. WEIGHT ALGORITHM\r\n4. MY WORDS PAGE";
			// 
			// CurrentUserTextBox
			// 
			CurrentUserTextBox.Location = new Point(158, 25);
			CurrentUserTextBox.Name = "CurrentUserTextBox";
			CurrentUserTextBox.ReadOnly = true;
			CurrentUserTextBox.Size = new Size(227, 34);
			CurrentUserTextBox.TabIndex = 12;
			CurrentUserTextBox.Tag = "";
			CurrentUserTextBox.Text = "Toliman";
			// 
			// CurrentUserLabel
			// 
			CurrentUserLabel.AutoSize = true;
			CurrentUserLabel.ForeColor = Color.Black;
			CurrentUserLabel.Location = new Point(6, 28);
			CurrentUserLabel.Name = "CurrentUserLabel";
			CurrentUserLabel.Size = new Size(123, 26);
			CurrentUserLabel.TabIndex = 7;
			CurrentUserLabel.Text = "Current user";
			// 
			// AddWordsErrorProvider
			// 
			AddWordsErrorProvider.ContainerControl = this;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(12F, 26F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(804, 361);
			Controls.Add(MainTabControl);
			Font = new Font("Comic Sans MS", 14.25F);
			ForeColor = Color.White;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Location = new Point(800, 1300);
			Margin = new Padding(5, 6, 5, 6);
			MaximumSize = new Size(820, 400);
			MinimumSize = new Size(820, 400);
			Name = "MainForm";
			Text = "VocabularyTrainer";
			MainTabControl.ResumeLayout(false);
			TrainYourselfPage.ResumeLayout(false);
			TrainYourselfPage.PerformLayout();
			AddNewWordsPage.ResumeLayout(false);
			AddNewWordsPage.PerformLayout();
			UserPage.ResumeLayout(false);
			UserPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)AddWordsErrorProvider).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private TabControl MainTabControl;
        private TabPage TrainYourselfPage;
        private TabPage AddNewWordsPage;
        private Button AddDataButton;
        private Label EnterHereLabel;
        private Label TranslationLabel;
        private Label WordToLearnLabel;
        private TextBox InputTranslationTextBox;
        private TextBox InputWordTextBox;
        private ErrorProvider AddWordsErrorProvider;
        private TextBox DisplayWordTextBox;
        private Button ShowNextButton;
        private Button ShowTranslationButton;
        private TextBox DisplayTranslationTextBox;
        private Button DeleteWordButton;
        private TabPage UserPage;
        private Label CurrentUserLabel;
		private TextBox CurrentUserTextBox;
		private TextBox textBox1;
	}
}