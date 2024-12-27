namespace HelloMaUI.Views;
public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public NotePage()
    {
        InitializeComponent();
        if (File.Exists(_fileName))
        {
            TextEdit.Text = File.ReadAllText(_fileName);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if(sender is Microsoft.Maui.Controls.Button button)
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
}