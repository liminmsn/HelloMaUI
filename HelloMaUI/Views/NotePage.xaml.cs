namespace HelloMaUI.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Microsoft.Maui.Controls.Button button)
        {
            string btn_key = button.Text;
            switch (btn_key)
            {
                case "Save":
                    File.WriteAllText(_fileName, TextEdit.Text);
                    await Shell.Current.GoToAsync("..");
                    break;
                case "Delete":
                    if (BindingContext is Models.Note note)
                    {
                        // Delete the file.
                        if (File.Exists(note.Filename))
                            File.Delete(note.Filename);
                    }

                    await Shell.Current.GoToAsync("..");
                    break;
            }
        }
    }
    private void LoadNote(string fileName)
    {
        Models.Note noteModel = new()
        {
            Filename = fileName
        };
        if (File.Exists(_fileName))
        {
            noteModel.Date = File.GetCreationTime(_fileName);
            noteModel.Text = File.ReadAllText(_fileName);
        }

        BindingContext = noteModel;
    }

    public string ItemId
    {
        set { LoadNote(value); }
    }
}
