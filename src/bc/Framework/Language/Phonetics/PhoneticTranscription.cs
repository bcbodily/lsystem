using System;
using System.Collections.Generic;
using System.Text;

namespace bc.Framework.Language.Phonetics
{
    public struct PhoneticTranscription : IEquatable<PhoneticTranscription>
    {
        public PhoneticTranscription(IEnumerable<Phone> phones)
        {
            Phones = new List<Phone>(phones);
        }
        private IList<Phone> Phones { get; init; }

        public bool Equals(PhoneticTranscription other)
        {
            if (other.Phones.Count != Phones.Count) { return false; }
            for (int i = 0; i < Phones.Count; i++)
            {
                if (!Phones[i].Equals(other.Phones[i])) { return false; }
            }
            return true;
        }

        public static PhoneticTranscription operator +(PhoneticTranscription lhs, PhoneticTranscription rhs)
        {
            var newPhones = new List<Phone>(lhs.Phones);
            newPhones.AddRange(rhs.Phones);
            return new PhoneticTranscription(newPhones);
        }

        public override string ToString()
        {
            var body = "";
            foreach(var phone in Phones)
            {
                body += phone.Symbol;
            }
            return $"[{body}]";
        }
    }
}