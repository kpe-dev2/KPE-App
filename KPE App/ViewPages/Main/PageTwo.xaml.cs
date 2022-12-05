using KPE_App.Objects;
using Dapper;
using Microsoft.Data.SqlClient;

namespace KPE_App.ViewPages;

public partial class PageTwo : ContentPage
{
    int count = 0;

    public PageTwo()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private async void OnSQLClicked(object sender, EventArgs e)
    {
        var bla = await DBTest();
        if (bla != null)
            SQLBtn.Text = bla.FirstOrDefault().IOParts.ToString();
    }


    private async Task<List<ShiftDataObj>> DBTest()
    {
        List<ShiftDataObj> data = new();
        SqlConnectionStringBuilder builder = new()
        {
            DataSource = "192.168.188.63",
            UserID = "sa",
            Password = "kwdi40",
            InitialCatalog = "Modellanlage"
        };

        using SqlConnection con = new(builder.ConnectionString);

        try
        {
            var bla = await con.QueryAsync<ShiftDataObj>("SELECT TOP 1 IOParts FROM ShiftData ORDER BY ShiftStart DESC");
            data = bla.AsList();
        }
        catch (Exception ex)
        {
            //Console.WriteLine(ex.Message);
        }


        return data;
    }

}

