namespace HelloMaUI.Views;
public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public NotePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Microsoft.Maui.Controls.Button button)
        {
            string btn_key = button.Text;
            switch (btn_key)
            {
                case "Save":
                    File.WriteAllText(_fileName, TextEdit.Text);
                    break;
                case "Delete":
                    if (File.Exists(_fileName))
                    {
                        File.Delete(_fileName);
                    }
                    TextEdit.Text = string.Empty;
                    break;
            }
        }
    }
    private void LoadNote(string fileName)
    {
        Models.Note noteModel = new Models.Note();
        noteModel.Filename = fileName;
        if (File.Exists(_fileName))
        {
            noteModel.Date = File.GetCreationTime(_fileName);
            noteModel.Text = File.ReadAllText(_fileName);
        }

        BindingContext = noteModel;
    }
}