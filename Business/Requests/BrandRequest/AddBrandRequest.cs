namespace Business.Requests.BrandRequest;

public class AddBrandRequest
{ 
    public string Name { get; set; }
 
    public AddBrandRequest(string name)
    {
        this.Name = name;
        
    }
}
