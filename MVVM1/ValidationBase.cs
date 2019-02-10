using MVVM1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM1
{
    public abstract class ValidationBase : BindableBase
    {
        public ValidationErrors ValidationErrors { get; set; }
        public bool IsValid { get;  set; }

        protected ValidationBase()
        {
            this.ValidationErrors = new ValidationErrors();
        }

        protected abstract void ValidateSelf();

        protected abstract void ValidateSelfPass();

        protected abstract void ValidateSelfList(UserList users);

        protected abstract void ValidateSelfListLogin(UserList users);

        public void Validate()
        {
            this.ValidationErrors.Clear();
            this.ValidateSelf();
            this.IsValid = this.ValidationErrors.IsValid;
            this.OnPropertyChanged("IsValid");
            this.OnPropertyChanged("ValidationErrors");
        }

        public void ValidateLogin(UserList users)
        {
            this.ValidationErrors.Clear();
            this.ValidateSelfListLogin(users);
            this.IsValid = this.ValidationErrors.IsValid;
            this.OnPropertyChanged("IsValid");
            this.OnPropertyChanged("ValidationErrors");
        }
        public void ValidateRegister(UserList users)
        {
            this.ValidationErrors.Clear();
            this.ValidateSelfList(users);
            this.IsValid = this.ValidationErrors.IsValid;
            this.OnPropertyChanged("IsValid");
            this.OnPropertyChanged("ValidationErrors");
        }
        public void ValidatePass()
        {
            this.ValidationErrors.Clear();
            this.ValidateSelfPass();
            this.IsValid = this.ValidationErrors.IsValid;
            this.OnPropertyChanged("IsValid");
            this.OnPropertyChanged("ValidationErrors");
        }

    }
}
