namespace HelloMaUI.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
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
                    if (BindingContext is Models.Note note)
                        File.WriteAllText(note.Filename, TextEdit.Text);
                    await Shell.Current.GoToAsync("..");
                    break;
                case "Delete":
                    if (BindingContext is Models.Note note_)
                    {
                        // Delete the file.
                        if (File.Exists(note_.Filename))
                            File.Delete(note_.Filename);
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
        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }

    public string ItemId
    {
        set { LoadNote(value); }
    }
}
