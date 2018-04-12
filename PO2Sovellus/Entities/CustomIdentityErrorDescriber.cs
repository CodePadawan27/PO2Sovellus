using Microsoft.AspNetCore.Identity;
namespace PO2Sovellus.Entities
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError()
        {
            return new IdentityError
            {
                Code =
nameof(DefaultError),
                Description = $"Tuntematon virhe."
            };
        }
        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError
            {
                Code =
nameof(ConcurrencyFailure),
                Description = "Optimistisen samanaikaisuuskäsittelyn virhe, oliota on muutettu."
            };
        }
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code =
nameof(PasswordMismatch),
                Description = "Epäkelpo salasana."
            };
        }
        public override IdentityError InvalidToken()
        {
            return new IdentityError
            {
                Code =
nameof(InvalidToken),
                Description = "Virheellinen merkki."
            };
        }
        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError
            {
                Code =
nameof(LoginAlreadyAssociated),
                Description = "Tällä käyttäjätunnuksella on jo olemassa käyttäjä."
            };
        }
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code =
nameof(InvalidUserName),
                Description = $"Käyttäjätunnus '{userName}' on virheellinen, voi sisältää vain kirjaimia tai numeroita." }; }

public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code =
nameof(InvalidEmail),
                Description = $"Sähköpostiosoite '{email}' on virheellinen."
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code =
nameof(DuplicateUserName),
                Description = $"Käyttäjätunnus '{userName}' on jo varattu."
            };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code =
nameof(DuplicateEmail),
                Description = $"Sähköpostiosoite '{email}' on jo varattu."
            };
        }
        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError
            {
                Code =
nameof(InvalidRoleName),
                Description = $"Roolin nimi '{role}' on virheellinen."
            };
        }
        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError
            {
                Code =
nameof(DuplicateRoleName),
                Description = $"Roolin nimi '{role}' on jo varattu."
            };
        }
        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError
            {
                Code =
nameof(UserAlreadyHasPassword),
                Description = "Käyttäjällä on jo salasanajoukko."
            };
        }
        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError
            {
                Code =
nameof(UserLockoutNotEnabled),
                Description = "Uloskirjautuminen ei ole käytössä tälle käyttäjätunnukselle."
            };
        }
        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError
            {
                Code =
nameof(UserAlreadyInRole),
                Description = $"Käyttäjä on jo roolissa '{role}'."
            };
        }
        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError
            {
                Code =
nameof(UserNotInRole),
                Description = $"Käyttäjä ei ole roolissa '{role}'."
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code =
nameof(PasswordTooShort),
                Description = $"Salasanojen pitää olla vähintään {length} merkkiä."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code =
nameof(PasswordRequiresNonAlphanumeric),
                Description = "Salasanojen pitää sisältää vähintään yhden ei-alfanumeerisen merkin." }; }

public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code =
nameof(PasswordRequiresDigit),
                Description = "Salasanojen pitää sisältää vähintään yhden numeron ('0'-'9')."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code =
nameof(PasswordRequiresLower),
                Description = "Salasanojen pitää sisältää vähintään yhden pienaakkosen ('a'-'z')." }; }

public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code =
nameof(PasswordRequiresUpper),
                Description = "Salasanojen pitää sisältää vähintään yhden suuraakkosen ('A'-'Z')." }; }
            }
}