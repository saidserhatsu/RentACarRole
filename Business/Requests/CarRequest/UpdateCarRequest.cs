namespace Business
{    
    public class UpdateCarRequest
        {
            public string Plate { get; set; }

            public UpdateCarRequest(string plate)
            {
                Plate = plate;
            }
        }
    }
