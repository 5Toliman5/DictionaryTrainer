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
			this.components = new System.ComponentModel.Container();
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.MainTabControl = new TabControl();
			this.TrainYourselfPage = new TabPage();
			this.DeleteWordButton = new Button();
			this.DisplayTranslationTextBox = new TextBox();
			this.ShowNextButton = new Button();
			this.ShowTranslationButton = new Button();
			this.DisplayWordTextBox = new TextBox();
			this.AddNewWordsPage = new TabPage();
			this.AddDataButton = new Button();
			this.EnterHereLabel = new Label();
			this.TranslationLabel = new Label();
			this.WordToLearnLabel = new Label();
			this.InputTranslationTextBox = new TextBox();
			this.InputWordTextBox = new TextBox();
			this.UserPage = new TabPage();
			this.UserNameTextBox = new TextBox();
			this.CurrentUserLabel = new Label();
			this.AddWordsErrorProvider = new ErrorProvider(this.components);
			this.MainTabControl.SuspendLayout();
			this.TrainYourselfPage.SuspendLayout();
			this.AddNewWordsPage.SuspendLayout();
			this.UserPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.AddWordsErrorProvider).BeginInit();
			this.SuspendLayout();
			// 
			// MainTabControl
			// 
			this.MainTabControl.Controls.Add(this.TrainYourselfPage);
			this.MainTabControl.Controls.Add(this.AddNewWordsPage);
			this.MainTabControl.Controls.Add(this.UserPage);
			this.MainTabControl.Location = new Point(2, 3);
			this.MainTabControl.Name = "MainTabControl";
			this.MainTabControl.SelectedIndex = 0;
			this.MainTabControl.Size = new Size(799, 363);
			this.MainTabControl.TabIndex = 0;
			// 
			// TrainYourselfPage
			// 
			this.TrainYourselfPage.BackColor = Color.Transparent;
			this.TrainYourselfPage.Controls.Add(this.DeleteWordButton);
			this.TrainYourselfPage.Controls.Add(this.DisplayTranslationTextBox);
			this.TrainYourselfPage.Controls.Add(this.ShowNextButton);
			this.TrainYourselfPage.Controls.Add(this.ShowTranslationButton);
			this.TrainYourselfPage.Controls.Add(this.DisplayWordTextBox);
			this.TrainYourselfPage.ForeColor = Color.Black;
			this.TrainYourselfPage.Location = new Point(4, 35);
			this.TrainYourselfPage.Name = "TrainYourselfPage";
			this.TrainYourselfPage.Padding = new Padding(3);
			this.TrainYourselfPage.Size = new Size(791, 324);
			this.TrainYourselfPage.TabIndex = 0;
			this.TrainYourselfPage.Text = "Train yourself!";
			this.TrainYourselfPage.Enter += this.TrainYourselfPage_Enter;
			// 
			// DeleteWordButton
			// 
			this.DeleteWordButton.Location = new Point(314, 269);
			this.DeleteWordButton.Name = "DeleteWordButton";
			this.DeleteWordButton.Size = new Size(189, 42);
			this.DeleteWordButton.TabIndex = 4;
			this.DeleteWordButton.Text = "Delete";
			this.DeleteWordButton.UseVisualStyleBackColor = true;
			this.DeleteWordButton.Click += this.DeleteWordButton_Click;
			// 
			// DisplayTranslationTextBox
			// 
			this.DisplayTranslationTextBox.BackColor = SystemColors.Control;
			this.DisplayTranslationTextBox.Font = new Font("Comic Sans MS", 20.25F);
			this.DisplayTranslationTextBox.Location = new Point(101, 123);
			this.DisplayTranslationTextBox.Name = "DisplayTranslationTextBox";
			this.DisplayTranslationTextBox.ReadOnly = true;
			this.DisplayTranslationTextBox.Size = new Size(609, 45);
			this.DisplayTranslationTextBox.TabIndex = 3;
			this.DisplayTranslationTextBox.TextAlign = HorizontalAlignment.Center;
			// 
			// ShowNextButton
			// 
			this.ShowNextButton.Location = new Point(435, 199);
			this.ShowNextButton.Name = "ShowNextButton";
			this.ShowNextButton.Size = new Size(275, 42);
			this.ShowNextButton.TabIndex = 2;
			this.ShowNextButton.Text = "I remember!";
			this.ShowNextButton.UseVisualStyleBackColor = true;
			this.ShowNextButton.Click += this.ShowNextButton_Click;
			// 
			// ShowTranslationButton
			// 
			this.ShowTranslationButton.Location = new Point(101, 199);
			this.ShowTranslationButton.Name = "ShowTranslationButton";
			this.ShowTranslationButton.Size = new Size(275, 42);
			this.ShowTranslationButton.TabIndex = 1;
			this.ShowTranslationButton.Text = "Translation";
			this.ShowTranslationButton.UseVisualStyleBackColor = true;
			this.ShowTranslationButton.Click += this.ShowTranslationButton_Click;
			// 
			// DisplayWordTextBox
			// 
			this.DisplayWordTextBox.Font = new Font("Comic Sans MS", 20.25F);
			this.DisplayWordTextBox.Location = new Point(101, 57);
			this.DisplayWordTextBox.Name = "DisplayWordTextBox";
			this.DisplayWordTextBox.ReadOnly = true;
			this.DisplayWordTextBox.Size = new Size(609, 45);
			this.DisplayWordTextBox.TabIndex = 0;
			this.DisplayWordTextBox.TextAlign = HorizontalAlignment.Center;
			// 
			// AddNewWordsPage
			// 
			this.AddNewWordsPage.BackColor = Color.Transparent;
			this.AddNewWordsPage.Controls.Add(this.AddDataButton);
			this.AddNewWordsPage.Controls.Add(this.EnterHereLabel);
			this.AddNewWordsPage.Controls.Add(this.TranslationLabel);
			this.AddNewWordsPage.Controls.Add(this.WordToLearnLabel);
			this.AddNewWordsPage.Controls.Add(this.InputTranslationTextBox);
			this.AddNewWordsPage.Controls.Add(this.InputWordTextBox);
			this.AddNewWordsPage.ForeColor = Color.Black;
			this.AddNewWordsPage.Location = new Point(4, 35);
			this.AddNewWordsPage.Name = "AddNewWordsPage";
			this.AddNewWordsPage.Padding = new Padding(3);
			this.AddNewWordsPage.Size = new Size(791, 324);
			this.AddNewWordsPage.TabIndex = 1;
			this.AddNewWordsPage.Text = "Add new words!";
			// 
			// AddDataButton
			// 
			this.AddDataButton.BackColor = Color.Transparent;
			this.AddDataButton.ForeColor = Color.Black;
			this.AddDataButton.Location = new Point(38, 244);
			this.AddDataButton.Name = "AddDataButton";
			this.AddDataButton.Size = new Size(723, 54);
			this.AddDataButton.TabIndex = 7;
			this.AddDataButton.Text = "Add the data!";
			this.AddDataButton.UseVisualStyleBackColor = false;
			this.AddDataButton.Click += this.AddDataButton_Click;
			// 
			// EnterHereLabel
			// 
			this.EnterHereLabel.AutoSize = true;
			this.EnterHereLabel.Location = new Point(6, 23);
			this.EnterHereLabel.Name = "EnterHereLabel";
			this.EnterHereLabel.Size = new Size(140, 26);
			this.EnterHereLabel.TabIndex = 6;
			this.EnterHereLabel.Text = "Enter here the";
			// 
			// TranslationLabel
			// 
			this.TranslationLabel.AutoSize = true;
			this.TranslationLabel.Location = new Point(52, 114);
			this.TranslationLabel.Name = "TranslationLabel";
			this.TranslationLabel.Size = new Size(110, 26);
			this.TranslationLabel.TabIndex = 4;
			this.TranslationLabel.Text = "Translation";
			// 
			// WordToLearnLabel
			// 
			this.WordToLearnLabel.AutoSize = true;
			this.WordToLearnLabel.Location = new Point(27, 67);
			this.WordToLearnLabel.Name = "WordToLearnLabel";
			this.WordToLearnLabel.Size = new Size(135, 26);
			this.WordToLearnLabel.TabIndex = 3;
			this.WordToLearnLabel.Text = "Word to learn";
			// 
			// InputTranslationTextBox
			// 
			this.InputTranslationTextBox.Location = new Point(168, 114);
			this.InputTranslationTextBox.Name = "InputTranslationTextBox";
			this.InputTranslationTextBox.Size = new Size(593, 34);
			this.InputTranslationTextBox.TabIndex = 1;
			this.InputTranslationTextBox.Tag = "translation";
			this.InputTranslationTextBox.TextChanged += this.TextBox_Validating;
			// 
			// InputWordTextBox
			// 
			this.InputWordTextBox.Location = new Point(168, 64);
			this.InputWordTextBox.Name = "InputWordTextBox";
			this.InputWordTextBox.Size = new Size(593, 34);
			this.InputWordTextBox.TabIndex = 0;
			this.InputWordTextBox.Tag = "word to learn";
			this.InputWordTextBox.TextChanged += this.TextBox_Validating;
			// 
			// UserPage
			// 
			this.UserPage.BackColor = Color.Transparent;
			this.UserPage.Controls.Add(this.UserNameTextBox);
			this.UserPage.Controls.Add(this.CurrentUserLabel);
			this.UserPage.ForeColor = Color.Black;
			this.UserPage.Location = new Point(4, 35);
			this.UserPage.Name = "UserPage";
			this.UserPage.Padding = new Padding(3);
			this.UserPage.Size = new Size(791, 324);
			this.UserPage.TabIndex = 2;
			this.UserPage.Text = "User";
			// 
			// UserNameTextBox
			// 
			this.UserNameTextBox.Location = new Point(135, 25);
			this.UserNameTextBox.Name = "UserNameTextBox";
			this.UserNameTextBox.Size = new Size(250, 34);
			this.UserNameTextBox.TabIndex = 8;
			this.UserNameTextBox.Tag = "word to learn";
			this.UserNameTextBox.Text = "Toliman";
			// 
			// CurrentUserLabel
			// 
			this.CurrentUserLabel.AutoSize = true;
			this.CurrentUserLabel.ForeColor = Color.Black;
			this.CurrentUserLabel.Location = new Point(6, 28);
			this.CurrentUserLabel.Name = "CurrentUserLabel";
			this.CurrentUserLabel.Size = new Size(123, 26);
			this.CurrentUserLabel.TabIndex = 7;
			this.CurrentUserLabel.Text = "Current user";
			// 
			// AddWordsErrorProvider
			// 
			this.AddWordsErrorProvider.ContainerControl = this;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new SizeF(12F, 26F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			this.ClientSize = new Size(804, 361);
			this.Controls.Add(this.MainTabControl);
			this.Font = new Font("Comic Sans MS", 14.25F);
			this.ForeColor = Color.White;
			this.Icon = (Icon)resources.GetObject("$this.Icon");
			this.Location = new Point(800, 1300);
			this.Margin = new Padding(5, 6, 5, 6);
			this.MaximumSize = new Size(820, 400);
			this.MinimumSize = new Size(820, 400);
			this.Name = "MainForm";
			this.Text = "DictionaryTrainer";
			this.MainTabControl.ResumeLayout(false);
			this.TrainYourselfPage.ResumeLayout(false);
			this.TrainYourselfPage.PerformLayout();
			this.AddNewWordsPage.ResumeLayout(false);
			this.AddNewWordsPage.PerformLayout();
			this.UserPage.ResumeLayout(false);
			this.UserPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.AddWordsErrorProvider).EndInit();
			this.ResumeLayout(false);
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
        private TextBox UserNameTextBox;
    }
}