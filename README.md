# Small benchmark for method call overhead

## Results

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.5472/23H2/2023Update/SunValley3)
AMD Ryzen 3 5300G with Radeon Graphics 4.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-preview.3.25201.16
  [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2


| Method         | Mean      | Error     | StdDev    | Code Size |
|--------------- |----------:|----------:|----------:|----------:|
| Normal         | 1.0580 ns | 0.0192 ns | 0.0180 ns |     112 B |
| Virtual        | 1.0526 ns | 0.0118 ns | 0.0105 ns |     127 B |
| VirtualGeneric | 5.2218 ns | 0.1077 ns | 0.1708 ns |     269 B |
| Delegate       | 1.3134 ns | 0.0295 ns | 0.0539 ns |     103 B |
| Control        | 0.0745 ns | 0.0273 ns | 0.0268 ns |       1 B |
