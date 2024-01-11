using GaugeOMatic.Trackers;
using GaugeOMatic.Windows;
using Newtonsoft.Json;
using System;
using System.Numerics;
using static CustomNodes.CustomNodeManager;
using static CustomNodes.CustomNodeManager.Tween;
using static GaugeOMatic.Utility.Color;
using static GaugeOMatic.Widgets.AetherflowReplica;
using static GaugeOMatic.Widgets.WidgetTags;
using static GaugeOMatic.Widgets.WidgetUI;
using static GaugeOMatic.Windows.UpdateFlags;

namespace GaugeOMatic.Widgets;

public sealed unsafe class AetherflowReplica : CounterWidget
{
    public override WidgetInfo WidgetInfo => GetWidgetInfo;

    public static WidgetInfo GetWidgetInfo => new() 
    { 
        DisplayName = "Aetherflow Gems", 
        Author = "ItsBexy", 
        Description = "A recreation of Arcanist/Summoner/Scholar's Aetherflow Gauge.", 
        WidgetTags = Counter | Replica
    };

    public override CustomPartsList[] PartsLists { get; } = {
        new("ui/uld/JobHudSCH0.tex", 
            new(0, 76, 44, 44),
            new(44, 76, 40, 52), 
            new(84, 76, 44, 32), 
            new(0, 0, 57, 76), 
            new(57, 0, 38, 76),
            new(95, 0, 57, 76),
            new(0, 0, 37, 76), 
            new(113, 0, 39, 76)),
        new("ui/uld/JobHudSMN0.tex", 
            new(0, 76, 44, 44), 
            new(44, 76, 40, 52),
            new(0, 120, 44, 32))
    };

    #region Nodes

    public CustomNode SocketPlate;
    public CustomNode Gems;

    public override CustomNode BuildRoot()
    {
        var count = Config.AsTimer ? Config.TimerSize : Tracker.GetCurrentData().MaxCount;

        SocketPlate = BuildSocketPlate(count, out var size);
        Gems = BuildGems(count);

        return new CustomNode(CreateResNode(), SocketPlate, Gems).SetOrigin((size/2f)-1,37);
    }

    private CustomNode BuildSocketPlate(int count, out int size)
    {
        if (count == 1)
        {
            size = 76;
            return new(CreateResNode(), 
                       ImageNodeFromPart(0, 6).SetPos(0, 0), 
                       ImageNodeFromPart(0, 7).SetPos(37, 0));
        }

        var socketNodes = new CustomNode[count];
        var x = 0;
        for (var i = 0; i < count; i++)
        {
            var part = (ushort)(i == 0 ? 3 : i == count - 1 ? 5 : 4);
            socketNodes[i] = ImageNodeFromPart(0, part).SetPos(x, 0);
            x += i == 0 || i == count - 1 ? 57 : 38;
        }

        size = x;
        return new CustomNode(CreateResNode(), socketNodes).SetOrigin((size / 2f) - 1, 37);
    }

    private CustomNode BuildGems(int count)
    {
        var gemList = new CustomNode[count];
        for (var i = 0; i < count; i++)
        {
            var gem = ImageNodeFromPart(0, 0);
            var pulse = ImageNodeFromPart(0, 1).SetPos(2, -6).SetScale(1.2f, 0.9f).SetOrigin(20, 40).SetImageFlag(32);
            var pulsar = ImageNodeFromPart(0, 2).SetPos(0, 6).SetOrigin(22, 16).SetImageFlag(32);
            var spendGlow = ImageNodeFromPart(0, 1).SetPos(2, -8).SetScale(1.2f, 0.9f).SetOrigin(20, 40).SetImageFlag(32).SetAlpha(0);

            gemList[i] = new CustomNode(CreateResNode(), gem, pulse, pulsar, spendGlow).SetPos(15 + (38 * i), 15).SetOrigin(22, 22).SetAlpha(0);

            Tweens.Add(new(pulse, new(0) { ScaleX = 1.2f, Alpha = 0 }, new(360) { ScaleX = 1, Alpha = 201 }, new(770) { ScaleX = 0.9f, Alpha = 0 }) { Repeat = true, Ease = Eases.SinInOut });
        }

        return new(CreateResNode(), gemList);
    }

    #endregion

    #region Animations

    public override void ShowStack(int i)
    {
        var flipFactor = Math.Abs(Config.Angle) >= 90 ? -1 : 1;
        Tweens.Add(Gems[i].CreateTween(new(0) { ScaleX = flipFactor, ScaleY = 1, Alpha = 0, AddRGB = -19 }, new(120) { ScaleX = flipFactor, ScaleY = 1, Alpha = 255, AddRGB = new(0) }));

        var green = Config.BaseColor == 0;

        AddRGB addStep1 = green ? new(-20, 19, -20) : new(-20, -10, 19);
        AddRGB addStep2 = green ? new(-189, 200, -200) : new(-200, -100, 200);
        AddRGB addStep3 = green ? new(100, 200, -200) : new(-200, -100, 200);

        Tweens.Add(Gems[i][2].CreateTween(new(0) { ScaleX = 3.2f, ScaleY = 0.6f, Alpha = 255, AddRGB = addStep1 },
                                          new(90) { ScaleX = 4.9f, ScaleY = 0.6f, Alpha = 255, AddRGB = addStep2 },
                                          new(300) { ScaleX = 3, ScaleY = 0.2f, Alpha = 0, AddRGB = addStep3 }));

    }

    public override void HideStack(int i)
    {
        var flipFactor = Math.Abs(Config.Angle) >= 90 ? -1 : 1;
        Tweens.Add(Gems[i].CreateTween(new(0) { ScaleX = 1 * flipFactor, ScaleY = 1, Alpha = 255 }, new(300) { ScaleX = 1.5f * flipFactor, ScaleY = 1.5f, Alpha = 0 }));
        Tweens.Add(Gems[i][3].CreateTween(new(0) { Scale = 1.1f, Alpha = 135 }, new(50) { Scale = 1.1f, Alpha = 176 }, new(250) { ScaleX = 2.3f, ScaleY = 2f, Alpha = 0 }));
    }

    private void PlateVanish()
    {
        var flipFactor = Math.Abs(Config.Angle) >= 90 ? -1 : 1;
        var downScale = Config.Scale * 0.65f;
        Tweens.Add(new(WidgetRoot,
                       new(0) { ScaleX = Config.Scale, ScaleY = Config.Scale * flipFactor, Alpha = 255 },
                       new(150) { ScaleX = downScale, ScaleY = downScale * flipFactor, Alpha = 0 })
                       { Ease = Eases.SinInOut });
    }

    private void PlateAppear()
    {
        var flipFactor = Math.Abs(Config.Angle) >= 90 ? -1 : 1;
        var downScale = Config.Scale * 1.65f;
        Tweens.Add(new(WidgetRoot,
                       new(0) { ScaleX = downScale, ScaleY = downScale * flipFactor, Alpha = 0 },
                       new(200) { ScaleX = Config.Scale, ScaleY = Config.Scale * flipFactor, Alpha = 255 })
                       { Ease = Eases.SinInOut });
    }

    #endregion

    #region UpdateFuncs

    public override string? SharedEventGroup => null;

    public override void OnFirstRun(int count, int max)
    {
        for (var i = 0; i < count; i++) Gems[i].SetAlpha(255);
        FirstRun = false;
    }

    public override void OnDecreaseToMin() { if (Config.HideEmpty) PlateVanish(); }

    public override void OnIncreaseFromMin() { if (Config.HideEmpty || WidgetRoot.Alpha < 255) { PlateAppear(); } }

    #endregion

    #region Configs

    public class AetherflowReplicaConfig : CounterWidgetConfig
    {
        public Vector2 Position = new(0);
        public float Scale = 1;
        public int BaseColor = 1;
        public AddRGB ColorModifier = new(0);
        public float Angle;
        public ColorRGB FrameColor = new(100);
        public bool HideEmpty;

        public AetherflowReplicaConfig(WidgetConfig widgetConfig)
        {
            var config = widgetConfig.AetherflowReplicaCfg;

            if (config == null) return;

            Position = config.Position;
            Scale = config.Scale;
            BaseColor = config.BaseColor;
            ColorModifier = config.ColorModifier;
            Angle = config.Angle;
            FrameColor = config.FrameColor;
            HideEmpty = config.HideEmpty;

            AsTimer = config.AsTimer;
            TimerSize = config.TimerSize;
            InvertTimer = config.InvertTimer;
        }

        public AetherflowReplicaConfig() { }
    }

    public override CounterWidgetConfig GetConfig => Config;

    public AetherflowReplicaConfig Config = null!;

    public override void InitConfigs() => Config = new(Tracker.WidgetConfig);

    public override void ResetConfigs() => Config = new();

    public override void ApplyConfigs()
    {
        var flipFactor = Math.Abs(Config.Angle) >= 90?-1:1;
        WidgetRoot.SetPos(Config.Position)
                  .SetScale(Config.Scale,Config.Scale * flipFactor)
                  .SetRotation(Config.Angle,true)
                  .SetAlpha(Tracker.CurrentData.Count == 0 && Config.HideEmpty? 0 : 255);

        SocketPlate.SetScaleX(flipFactor)
                   .SetMultiply(Config.FrameColor);

        Gems.SetAddRGB(Config.ColorModifier);
        foreach (var gem in Gems.Children)
        {
            gem.SetScaleX(flipFactor);
            for (var i = 0; i < 4; i++)
                gem[i].Node->GetAsAtkImageNode()->PartsList = PartsLists[Config.BaseColor].AtkPartsList;
        }
    }

    public override void DrawUI(ref WidgetConfig widgetConfig, ref UpdateFlags update)
    {
        Heading("Layout");
        PositionControls("Position", ref Config.Position, ref update);
        ScaleControls("Scale", ref Config.Scale, ref update);
        FloatControls("Angle", ref Config.Angle, -180, 180, 1, ref update);

        Heading("Colors");
        RadioControls("Base Color", ref Config.BaseColor, new() { 1, 0 }, new() { "Pink", "Green" }, ref update);
        ColorPickerRGB("Color Modifier", ref Config.ColorModifier, ref update);
        ColorPickerRGB("Frame Tint", ref Config.FrameColor, ref update);

        Heading("Behavior");
        if (ToggleControls("Hide Empty", ref Config.HideEmpty, ref update))
        {
            if (Config.HideEmpty && Tracker.CurrentData.Count == 0) PlateVanish();
            if (!Config.HideEmpty && WidgetRoot.Alpha < 255) PlateAppear();
        }

        if (ToggleControls($"Use as {Tracker.TermGauge}", ref Config.AsTimer, ref update)) update |= Reset;
        if (Config.AsTimer)
        {
            if (ToggleControls($"Invert {Tracker.TermGauge}", ref Config.InvertTimer, ref update)) update |= Reset;
            if (IntControls($"{Tracker.TermGauge} Size", ref Config.TimerSize, 1, 20, 1, ref update)) update |= Reset;
        }

        if (update.HasFlag(Save)) ApplyConfigs();
        widgetConfig.AetherflowReplicaCfg = Config;
    }

    #endregion

    public AetherflowReplica(Tracker tracker) : base(tracker) { }
}

public partial class WidgetConfig
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] public AetherflowReplicaConfig? AetherflowReplicaCfg { get; set; }
}
