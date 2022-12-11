using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace julealgon.AdventOfCode._2022._10_CathodeRayTube;

internal class Cpu
{
    private readonly BehaviorSubject<int> cicle = new(0);
    private readonly BehaviorSubject<int> xregister = new(1);
    private readonly TextWriter videoOutput;

    public Cpu(TextWriter videoOutput)
    {
        this.videoOutput = videoOutput;
        Cicle = cicle;
        XRegister = xregister;
        SignalStrength = Cicle
            .WithLatestFrom(XRegister)
            .Select(pair => pair.First * pair.Second);

        Cicle.Skip(1).Subscribe(pair => DrawPixel());
    }

    public IObservable<int> Cicle { get; }

    public IObservable<int> XRegister { get; }

    public IObservable<int> SignalStrength { get; }

    private void DrawPixel()
    {
        const int columnsPerRow = 40;

        var pixelPosition = (cicle.Value - 1) % columnsPerRow;
        var pixelToDraw = GetPixelColor();
        this.videoOutput.Write(pixelToDraw);
        if (pixelPosition == columnsPerRow - 1)
        {
            this.videoOutput.WriteLine();
        }

        char GetPixelColor()
        {
            const char litPixel = '#';
            const char darkPixel = '.';

            if (pixelPosition == xregister.Value ||
                pixelPosition == xregister.Value - 1 ||
                pixelPosition == xregister.Value + 1)
            {
                return litPixel;
            }

            return darkPixel;
        }
    }

    public void ProcessCommand(string command)
    {
        _ = command switch
        {
            "noop" => Noop(),
            ['a', 'd', 'd', 'x', ' ', .. var valueText] => AddX(int.Parse(valueText)),
            _ => throw new InvalidOperationException(),
        };

        bool Noop()
        {
            cicle.OnNext(cicle.Value + 1);

            return true;
        }

        bool AddX(int value)
        {
            cicle.OnNext(cicle.Value + 1);
            cicle.OnNext(cicle.Value + 1);

            xregister.OnNext(xregister.Value + value);

            return true;
        }
    }
}
