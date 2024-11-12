using System;

class TV
{
    public void On() => Console.WriteLine("Телевизор включен");
    public void Off() => Console.WriteLine("Телевизор выключен");
    public void SetChannel(int channel) => Console.WriteLine($"Канал установлен на {channel}");
}

class AudioSystem
{
    public void On() => Console.WriteLine("Аудиосистема включена");
    public void Off() => Console.WriteLine("Аудиосистема выключена");
    public void SetVolume(int volume) => Console.WriteLine($"Громкость установлена на {volume}");
}

class DVDPlayer
{
    public void Play() => Console.WriteLine("Воспроизведение DVD началось");
    public void Pause() => Console.WriteLine("Воспроизведение DVD приостановлено");
    public void Stop() => Console.WriteLine("Воспроизведение DVD остановлено");
}

class GameConsole
{
    public void On() => Console.WriteLine("Игровая консоль включена");
    public void StartGame() => Console.WriteLine("Игра запущена");
}

class HomeTheaterFacade
{
    private TV tv;
    private AudioSystem audioSystem;
    private DVDPlayer dvdPlayer;
    private GameConsole gameConsole;

    public HomeTheaterFacade(TV tv, AudioSystem audioSystem, DVDPlayer dvdPlayer, GameConsole gameConsole)
    {
        this.tv = tv;
        this.audioSystem = audioSystem;
        this.dvdPlayer = dvdPlayer;
        this.gameConsole = gameConsole;
    }

    public void WatchMovie()
    {
        tv.On();
        audioSystem.On();
        dvdPlayer.Play();
        Console.WriteLine("Наслаждайтесь фильмом!");
    }

    public void StopMovie()
    {
        dvdPlayer.Stop();
        audioSystem.Off();
        tv.Off();
        Console.WriteLine("Фильм остановлен.");
    }

    public void StartGame()
    {
        gameConsole.On();
        gameConsole.StartGame();
        Console.WriteLine("Начинаем играть!");
    }

    public void StopGame()
    {
        gameConsole.On();
        Console.WriteLine("Игра остановлена.");
    }

    public void ListenToMusic()
    {
        tv.On();
        audioSystem.On();
        audioSystem.SetVolume(30);
        Console.WriteLine("Прослушивание музыки.");
    }

    public void SetVolume(int volume)
    {
        audioSystem.SetVolume(volume);
    }
}

class Program
{
    static void Main()
    {
        var tv = new TV();
        var audioSystem = new AudioSystem();
        var dvdPlayer = new DVDPlayer();
        var gameConsole = new GameConsole();

        var homeTheater = new HomeTheaterFacade(tv, audioSystem, dvdPlayer, gameConsole);

        homeTheater.WatchMovie();
        homeTheater.SetVolume(20);
        homeTheater.StopMovie();

        homeTheater.StartGame();
        homeTheater.StopGame();

        homeTheater.ListenToMusic();
    }
}
