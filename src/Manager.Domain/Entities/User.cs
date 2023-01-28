using System;
using System.Collections.Generic;
using Manager.Domain.Validator;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }   
        // public int Age { get; private set; }

        //EF
        protected User() {}

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _erros = new List<string>();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        // public void CurrentAge()
        // {
        //     Validate();
        // }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                {
                    _erros.Add(error.ErrorMessage);
                }

                throw new Exception($"Alguns campos estão inválidos. Por favor corrige-os!"+ _erros[0]);
            }

            return true;
        }
    }
}