using System;
using MvvmCross.Core.ViewModels;
using NowyOssus.Model;

namespace NowyOssus.ViewModels
{
    public class DetailViewModel : MvxViewModel<Character>
    {
        public DetailViewModel()
        {
        }

        private Character _currentCharacter;
        public Character CurrentCharacter 
        {
            get { return _currentCharacter; }
            set
            {
                _currentCharacter = value;
                RaisePropertyChanged(() => CurrentCharacter);
            }
        }

        public string Url => "https://vignette.wikia.nocookie.net/austinally/images/1/14/Random_picture_of_shark.png/revision/latest?cb=20150911004230";

        public override void Prepare(Character parameter)
        {
            CurrentCharacter = parameter;
        }
    }
}
