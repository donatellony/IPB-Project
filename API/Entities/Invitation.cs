using API.Data;

namespace API.Entities
{
    public class Invitation
    {
        public string Name { get; set; }
        public SchoolType School { get; set; }
        private static readonly InvitationsDb Context = InvitationsDb.GetInstance();

        public Invitation()
        {
            
        }

        // public Invitation(string name, SchoolType school, string place)
        // {
        //     Name = name;
        //     School = school;
        //     Place = place;
        // }

        public string GetInvitationText()
        {
            return $"Witamy, Panie/Pani {Name} \n" +
                   $"Dziękujęmy za zgłoszenie. Jest nam miło powiadomić, że przeszedłeś(aś) do następnego etapu rekrutacji.\n" +
                   $"Następnym krokiem jest seria testów, wyniki której będą decydowali o przyjęciu do Kolegium Winterholdu. \n" +
                   $"{Context.GetText(School)}\n" +
                   $"Życzymy powodzenia!";
        }
    }
}