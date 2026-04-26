using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Models.Requests;

public class CreateUserRequestModel
{
    [Required]
    public Guid? ExternalId { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Username { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(256)]
    public string? PasswordHash { get; set; }
}