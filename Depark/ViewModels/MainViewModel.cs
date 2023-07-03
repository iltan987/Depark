using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Depark.Contracts.Services;
using Depark.Models;
using Depark.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Depark.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly ICompanyService companyService;

        private ObservableCollection<CompanyViewModel> companies;
        public ObservableCollection<CompanyViewModel> Companies
        {
            get => companies;
            set => SetProperty(ref companies, value);
        }

        private bool isLoading = true;
        public bool IsLoading
        {
            get => isLoading;
            set => SetProperty(ref isLoading, value);
        }

        public MainViewModel(ICompanyService companyService)
        {
            this.companyService = companyService;
            companies = new ObservableCollection<CompanyViewModel>();
            LoadCompanies();
            AddCompanyCommand = new AsyncRelayCommand(AddCompany);
            UpdateCompanyCommand = new AsyncRelayCommand(UpdateCompany, () => SelectedCompany != null);
            RemoveCompanyCommand = new AsyncRelayCommand(RemoveCompany, () => SelectedCompany != null);
            OpenEditCompanyMenu = new RelayCommand(OpenEditCompany, () => SelectedCompany != null);
        }

        private async void OpenEditCompany()
        {
            await DialogHost.Show(new UpdateCompanyView(this), "RootDialog");
        }

        private async Task AddCompany()
        {
            IsLoading = true;
            Company com = new() { Logo = logo, Name = name, Sector = sector, Location = location, Type = type, Website = website, Extra = extra };
            await companyService.CreateAsync(com);
            Companies.Add(new CompanyViewModel(com));
            IsLoading = false;
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        private async Task UpdateCompany()
        {
            IsLoading = true;

            SelectedCompany!.Logo = logo;
            SelectedCompany.Name = name;
            SelectedCompany.Sector = sector;
            SelectedCompany.Location = location;
            SelectedCompany.Type = type;
            SelectedCompany.Website = website;
            SelectedCompany.Extra = extra;
            await companyService.UpdateAsync(SelectedCompany.company);
            OnPropertyChanged(nameof(SelectedCompany));
            OnPropertyChanged(nameof(Companies));
            IsLoading = false;
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        private async Task RemoveCompany()
        {
            IsLoading = true;

            await companyService.DeleteAsync(SelectedCompany!.Id);
            Companies.Remove(SelectedCompany);
            IsLoading = false;
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        private async void LoadCompanies()
        {
            try
            {
                var companies = await companyService.GetAllAsync();
                Companies = new ObservableCollection<CompanyViewModel>(companies.Select(f => new CompanyViewModel(f)));
            }
            finally
            {
                IsLoading = false;
            }
        }

        private CompanyViewModel? selectedCompany;
        public CompanyViewModel? SelectedCompany
        {
            get => selectedCompany;
            set
            {
                SetProperty(ref selectedCompany, value);

                Logo = value?.Logo;
                Name = value?.Name;
                Sector = value?.Sector;
                Location = value?.Location;
                Type = value?.Type;
                Website = value?.Website;
                Extra = value?.Extra;

                UpdateCompanyCommand.NotifyCanExecuteChanged();
                RemoveCompanyCommand.NotifyCanExecuteChanged();
                OpenEditCompanyMenu.NotifyCanExecuteChanged();
            }
        }

        private string? logo;
        public string? Logo
        {
            get => logo;
            set => SetProperty(ref logo, value);
        }

        private string? name;
        public string? Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string? sector;
        public string? Sector
        {
            get => sector;
            set => SetProperty(ref sector, value);
        }

        private string? location;
        public string? Location
        {
            get => location;
            set => SetProperty(ref location, value);
        }

        private string? type;
        public string? Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        private string? website;
        public string? Website
        {
            get => website;
            set => SetProperty(ref website, value);
        }

        private string? extra;
        public string? Extra
        {
            get => extra;
            set => SetProperty(ref extra, value);
        }

        public AsyncRelayCommand AddCompanyCommand { get; set; }

        public AsyncRelayCommand UpdateCompanyCommand { get; set; }

        public AsyncRelayCommand RemoveCompanyCommand { get; set; }

        public RelayCommand OpenEditCompanyMenu { get; set; }
    }
}