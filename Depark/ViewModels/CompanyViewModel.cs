using CommunityToolkit.Mvvm.ComponentModel;
using Depark.Models;

namespace Depark.ViewModels
{
    public class CompanyViewModel : ObservableObject
    {
        public Company company { get; }

        public CompanyViewModel(Company company)
        {
            this.company = company;
        }

        public int Id
        {
            get => company.Id;
            set
            {
                if (company.Id != value)
                {
                    company.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? Logo
        {
            get => company.Logo;
            set
            {
                if (company.Logo != value)
                {
                    company.Logo = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? Name
        {
            get => company.Name;
            set
            {
                if (company.Name != value)
                {
                    company.Name = value;
                    OnPropertyChanged();
                }
            }
        }


        public string? Sector
        {
            get => company.Sector;
            set
            {
                if (company.Sector != value)
                {
                    company.Sector = value;
                    OnPropertyChanged();
                }
            }
        }


        public string? Location
        {
            get => company.Location;
            set
            {
                if (company.Location != value)
                {
                    company.Location = value;
                    OnPropertyChanged();
                }
            }
        }


        public string? Type
        {
            get => company.Type;
            set
            {
                if (company.Type != value)
                {
                    company.Type = value;
                    OnPropertyChanged();
                }
            }
        }


        public string? Website
        {
            get => company.Website;
            set
            {
                if (company.Website != value)
                {
                    company.Website = value;
                    OnPropertyChanged();
                }
            }
        }


        public string? Extra
        {
            get => company.Extra;
            set
            {
                if (company.Extra != value)
                {
                    company.Extra = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}