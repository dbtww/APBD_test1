namespace APBD_test01.Models.DTOs;

public class CreateBookingRequestDTO
{
    public int ID {get;set;}
    public DateTime date { get; set; }
    public List<getGuestInfoRequestDTO> bookedGuests { get; set; }
}

public class getGuestInfoRequestDTO
{
    public int ID {get;set;}
    public string firstName { get; set; }
    public string lastName { get; set; }
    public DateTime dateOfBirth { get; set; }
}

public class AttractionesDTO
{
    public List<getAttractionesRequestDTO> attractions { get; set; }
}

public class getAttractionesRequestDTO
{
    public int ID { get; set; }
    public string name { get; set; }
    public double price { get; set; }
    public int amount { get; set; }
}