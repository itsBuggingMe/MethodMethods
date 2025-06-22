using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Runtime.CompilerServices;

namespace MethodMethods;

[DisassemblyDiagnoser]
public class Methods : Base
{
    const MethodImplOptions SupressOpt = MethodImplOptions.NoInlining | MethodImplOptions.AggressiveOptimization;

    static void Main(string[] args) => BenchmarkRunner.Run<Methods>();

    Base _base;
    Action _delegate;

    [GlobalSetup]
    public void Setup()
    {
        _base = new Methods();
        _delegate = _base.M;
    }

    [MethodImpl(SupressOpt)]
    [Benchmark(OperationsPerInvoke = 8)]
    public void Normal()
    {
        _base.M(); _base.M(); _base.M(); _base.M();
        _base.M(); _base.M(); _base.M(); _base.M();
    }

    [MethodImpl(SupressOpt)]
    [Benchmark(OperationsPerInvoke = 8)]
    public void Virtual()
    {
        _base.V(); _base.V(); _base.V(); _base.V();
        _base.V(); _base.V(); _base.V(); _base.V();
    }

    [MethodImpl(SupressOpt)]
    [Benchmark(OperationsPerInvoke = 8)]
    public void VirtualGeneric()
    {
        _base.VG<int>(); _base.VG<int>(); _base.VG<int>(); _base.VG<int>();
        _base.VG<int>(); _base.VG<int>(); _base.VG<int>(); _base.VG<int>();
    }

    [MethodImpl(SupressOpt)]
    [Benchmark(OperationsPerInvoke = 8)]
    public void Delegate()
    {
        _delegate(); _delegate(); _delegate(); _delegate();
        _delegate(); _delegate(); _delegate(); _delegate();
    }

    [MethodImpl(SupressOpt)]
    [Benchmark]
    public void Control()
    {

    }

    public override void V() { }
    public override void VG<T>() { }
}

public abstract class Base
{
    public abstract void V();
    public abstract void VG<T>();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void M() { }
}