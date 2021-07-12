namespace Enhanced.Models
{
    public record Post(
        int UserId,
        int Id,
        string Title,
        string Body
    );

    public record Comment(
        int PostId,
        int Id,
        string Name,
        string Email,
        string Body
    );

    public record GeoPos(
        string Lat,
        string Long);

    public record Address(
        string Street,
        string Suite,
        string City,
        string ZipCode,
        GeoPos Geo);
    public record Company(
        string Name,
        string CatchPhrase,
        string Bs
    );

    public record User(
        int Id,
        string Name,
        string Email,
        Address Address,
        string Phone,
        string Website,
        Company Company
    );
}
