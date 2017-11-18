using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using NowyOssus.Messages;
using NowyOssus.Model;
using NowyOssus.Service;
using Refit;

namespace NowyOssus.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly IMvxMessenger _messenger;

        private readonly MvxSubscriptionToken _token;

        public MainViewModel(
            IMvxNavigationService navigationService,
            IDialogService dialogService,
            IMvxMessenger messenger)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _messenger = messenger;

            Characters = new MvxObservableCollection<Character>();
            CharacterSelected = new MvxAsyncCommand<Character>(NavigateToDetail);
            LoadCharactersData = new MvxAsyncCommand(GetData);

            _token = messenger.Subscribe<DecisionMessage>((msg) => 
            {
                if (msg.Decision) 
                {
                    LoadData();
                }
            });
        }
        
        public override Task Initialize()
        {
            GetData();

            return base.Initialize();
        }
        
        public IMvxCommand<Character> CharacterSelected { get; private set; }
        public IMvxCommand LoadCharactersData { get; private set; }

        private MvxObservableCollection<Character> _characters;
        public MvxObservableCollection<Character> Characters 
        {
            get { return _characters; }
            set 
            {
                _characters = value;
                RaisePropertyChanged(() => Characters);
            }
        }

        private bool _charactersLoading;
        public bool CharactersLoading 
        {
            get { return _charactersLoading; }
            set
            {
                _charactersLoading = value;
                RaisePropertyChanged(() => CharactersLoading);
            }
        }

        private async Task GetData() 
        {
            if (Characters.Count != 0) 
            {
                _dialogService.ShowAcceptanceDialog();
            }
            else 
            {
                await LoadData();
            }
        }

        private async Task NavigateToDetail(Character selectedCharacter)
        {
            await _navigationService.Navigate<DetailViewModel, Character>(selectedCharacter);
        }

        private async Task LoadData()
        {
            CharactersLoading = true;

            var starWarsApi = RestService.For<IStarWarsApi>("https://swapi.co/api");

            var characters = await starWarsApi.GetCharacters(1);

            Characters.AddRange(characters.Results);

            CharactersLoading = false;
        }
    }
}