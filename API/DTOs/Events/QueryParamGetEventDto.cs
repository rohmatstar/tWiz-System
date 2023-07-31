namespace API.DTOs.Events;

public class QueryParamGetEventDto
{
    // all, published, draft
    public string? Publication { get; set; }

    // all, private, public
    public string? Visibility { get; set; }

    // all, offline, online
    public string? Type { get; set; }

    // newest, older
    public string? SortBy { get; set; }
}

