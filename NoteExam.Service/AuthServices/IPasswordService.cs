namespace NoteExam.Service.AuthServices;

public interface IPasswordService
{
	string GenerateSalt();
	string HashPassword(string password, string salt);
	bool VerifyPassword(string password, string salt, string hash);
	bool PasswordsMatch(string password, string repeatPassword);
	bool PasswordMeetsRequirements(string password);
	string GetPasswordRequirements(string password);
}
