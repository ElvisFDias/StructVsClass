using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StructVsClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
            /*
             var op = new DimensaoOperacao();

            var crono = Stopwatch.StartNew();
            op.InserirDimensaoClass();
            var inserirDimensaoClass = $"InserirDimensaoClass: {crono.ElapsedMilliseconds} ms";


            crono.Restart();
            op.InserirDimensaStruct();
            var inserirDimensaStruct = $"InserirDimensaStruct: {crono.ElapsedMilliseconds} ms";

            crono.Restart();
            op.InserirDimensaoStructEquatable();
            var inserirDimensaoStructEquatable = $"InserirDimensaoStructEquatable: {crono.ElapsedMilliseconds} ms";

            Console.WriteLine(inserirDimensaoClass);
            Console.WriteLine(inserirDimensaStruct);
            Console.WriteLine(inserirDimensaoStructEquatable);
            Console.ReadLine();
            */
        }
    }

    [SimpleJob(RunStrategy.Monitoring)]
    [MemoryDiagnoser]
    public class DimensaoOperacao
    {
        const int maximoItens = 3_000_000;

       // [Benchmark]
        public bool InserirDimensaoClass()
        {
            var random = new Random();
            var lista = new List<DimensaoClass>();
            var dimensaoNaoInserida = new DimensaoClass() { Altura = -1, Largura = 0, Profundidade = 0 };

            for (int i = 0; i < maximoItens; i++)
            {
                var dimensao = new DimensaoClass() { Altura = random.Next(), Largura = random.Next(), Profundidade = random.Next() };

                lista.Add(dimensao);
            }

            return lista.Contains(dimensaoNaoInserida);
        }

        //[Benchmark]
        public bool InserirDimensaStruct()
        {
            var random = new Random();
            var lista = new List<DimensaoStruct>();
            var dimensaoNaoInserida = new DimensaoStruct() { Altura = -1, Largura = 0, Profundidade = 0 };

            for (int i = 0; i < maximoItens; i++)
            {
                var dimensao = new DimensaoStruct() { Altura = random.Next(), Largura = random.Next(), Profundidade = random.Next() };

                lista.Add(dimensao);
            }

            return lista.Contains(dimensaoNaoInserida);
        }


       [Benchmark]
        public bool InserirDimensaoStructEquatable()
        {
            var random = new Random();
            var lista = new List<DimensaoStructEquatable>();
            var dimensaoNaoInserida = new DimensaoStructEquatable() { Altura = -1, Largura = 0, Profundidade = 0 };

            for (int i = 0; i < maximoItens; i++)
            {
                var dimensao = new DimensaoStructEquatable() { Altura = random.Next(), Largura = random.Next(), Profundidade = random.Next() };

                lista.Add(dimensao);
            }

            return lista.Contains(dimensaoNaoInserida);
        }
    }
}
