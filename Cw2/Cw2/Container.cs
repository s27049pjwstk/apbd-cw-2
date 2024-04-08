namespace Cw2;

public abstract class Container {
    private double _mass; // [kg] Cargo weight
    private double _height; // [cm]
    private double _tare; // [kg] Empty weight
    private double _depth; // [cm]
    private readonly string _serialNumber; // KON-C-1
    private double _capacity; // [kg] Max Cargo weight
    string? CargoProductName { get; set; }
    static int index = 1;

    Container(double height, double tare, double depth, double capacity, char type) {
        _mass = 0;
        _height = height;
        _tare = tare;
        _depth = depth;
        _serialNumber = CreateSerialNumber(type);
        _capacity = capacity;
    }

    public double Mass {
        get => _mass;
        set {
            if (value < 0) throw new ArgumentException("Mass cannot be less than zero!");
            _mass = value;
        }
    }

    public double Height {
        get => _height;
        set {
            if (value < 0) throw new ArgumentException("Height cannot be less than zero!");
            _height = value;
        }
    }

    public double Tare {
        get => _tare;
        set {
            if (value < 0) throw new ArgumentException("Tare cannot be less than zero!");
            _tare = value;
        }
    }

    public double Depth {
        get => _depth;
        set {
            if (value < 0) throw new ArgumentException("Depth cannot be less than zero!");
            _depth = value;
        }
    }

    public double Capacity {
        get => _capacity;
        set {
            if (value < 0) throw new ArgumentException("Load cannot be less than zero!");
            _capacity = value;
        }
    }

    public abstract void load(string cargoName, double cargoWeight);
    public abstract void unload();

    public bool IsEmpty() {
        return _mass == 0;
    }


    private static String CreateSerialNumber(char type) {
        return $"KON-{type}-{index++}";
    }

    public override string ToString() {
        return $"{_serialNumber}" +
               $"[{_height}x{_depth};{_tare}]" +
               $"[Load:{_mass}/{_capacity}({CargoProductName})]";
    }
}

public interface IHazardNotifier {
    void NotifyHazard(string message);
}

public class OverfillException : Exception {
    public OverfillException(string serialNumber)
        : base($"Container {serialNumber} loading failed! Cargo mass exceeds container capacity!") {
    }
}