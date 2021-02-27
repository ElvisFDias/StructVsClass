using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StructVsClass
{
    
    public class DimensaoClass
    {
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Profundidade { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DimensaoClass @class &&
                   Altura == @class.Altura &&
                   Largura == @class.Largura &&
                   Profundidade == @class.Profundidade;
        }
    }

    public struct DimensaoStruct
    {
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Profundidade { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DimensaoStruct @struct &&
                   Altura == @struct.Altura &&
                   Largura == @struct.Largura &&
                   Profundidade == @struct.Profundidade;
        }
    }

    public struct DimensaoStructEquatable : IEquatable<DimensaoStructEquatable>
    {
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Profundidade { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DimensaoStructEquatable @struct &&
                   Altura == @struct.Altura &&
                   Largura == @struct.Largura &&
                   Profundidade == @struct.Profundidade;
        }

        public bool Equals([AllowNull] DimensaoStructEquatable other)
        {
            return 
                Altura == other.Altura &&
                Largura == other.Largura &&
                Profundidade == other.Profundidade;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Altura, Largura, Profundidade);
        }
    }
}
