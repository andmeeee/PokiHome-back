using Microsoft.AspNetCore.Mvc;


namespace PokiHome.Demo.Data.Entities;

public class Home
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Price { get; set; }
    public string? ImgURL { get; set; }
}
