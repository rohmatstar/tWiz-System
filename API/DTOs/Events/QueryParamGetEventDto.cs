namespace API.DTOs.Events;

public class QueryParamGetEventDto
{
    // all, published, draft
    public string? publication_status { get; set; }

    // all, private, public
    public string? visibility { get; set; }

    // all, offline, online
    public string? place_type { get; set; }

    // newest, older
    public string? sort_by { get; set; }
}

