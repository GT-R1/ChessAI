using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class ChessBoard : IChessBoard
    {
        public List<ChessPiece> WhitePieces;
        public List<ChessPiece> BlackPieces;
        public List<ChessPiece> RemovedWhitePieces;
        public List<ChessPiece> RemovedBlackPieces;

        public ChessBoard()
        {
            WhitePieces = new List<ChessPiece>();
            BlackPieces = new List<ChessPiece>();
            RemovedWhitePieces = new List<ChessPiece>();
            RemovedBlackPieces = new List<ChessPiece>();
        }

        public void InitializeBoard()
        {
            WhitePieces = InitializeWhitePieces();
            BlackPieces = InitializeBlackPieces();
        }

        public ChessPiece PromotePiece(ChessPiece piece, PieceName name, PieceColor color) //ReplacePiece (piece - piece to replace)
        {
            if (color == PieceColor.White)
            {
                piece.PromoteTo(name, new PieceMoves[] { }); //without piecemoves!!
            }
            else
            {
                piece.PromoteTo(name, new PieceMoves[] { });
            }

            return null;
        }

        public ChessPiece MovePiece(ChessPiece piece, PieceColor color)
        {
            if (color == PieceColor.White)
            {
            }
            else
            {
            }

            return null;
        }

        public ChessPiece RemovePiece(ChessPiece piece, PieceColor color)
        {
            if (color == PieceColor.White)
            {
                WhitePieces.Remove(piece);
                RemovedWhitePieces.Add(piece);
            }
            else
            {
                BlackPieces.Remove(piece);
                RemovedBlackPieces.Add(piece);
            }

            return null;
        }

        #region InitializePieces

        private List<ChessPiece> InitializeWhitePieces()
        {
            List<ChessPiece> whitePieces = new List<ChessPiece>();

            whitePieces.AddRange(CreatePawns(PieceColor.White, null));
            whitePieces.AddRange(CreateHorses(PieceColor.White, null));
            whitePieces.AddRange(CreateBishops(PieceColor.White, null));
            whitePieces.AddRange(CreateRooks(PieceColor.White, null));
            whitePieces.Add(CreateQueen(PieceColor.White, null));
            whitePieces.Add(CreateKing(PieceColor.White, null));

            return whitePieces;
        }

        private List<ChessPiece> InitializeBlackPieces()
        {
            List<ChessPiece> blackPieces = new List<ChessPiece>();

            blackPieces.AddRange(CreatePawns(PieceColor.Black, null));
            blackPieces.AddRange(CreateHorses(PieceColor.Black, null));
            blackPieces.AddRange(CreateBishops(PieceColor.Black, null));
            blackPieces.AddRange(CreateRooks(PieceColor.Black, null));
            blackPieces.Add(CreateQueen(PieceColor.Black, null));
            blackPieces.Add(CreateKing(PieceColor.Black, null));

            return blackPieces;
        }

        private ChessPiece[] CreatePawns(PieceColor color, string[] startingPosition)
        {
            List<ChessPiece> pawns = new List<ChessPiece>();

            for (int i = 0; i < 8; i++)
            {
                pawns.Add(new ChessPiece(PieceName.Pawn, color, new PieceMoves[] { PieceMoves.SingleSquare, PieceMoves.DoubleSquare }, startingPosition[i]));
            }

            return pawns.ToArray();
        }

        private ChessPiece[] CreateHorses(PieceColor color, string[] startingPosition)
        {
            List<ChessPiece> horses = new List<ChessPiece>();

            for (int i = 0; i < 2; i++)
            {
                horses.Add(new ChessPiece(PieceName.Knight, color, new PieceMoves[] { }, startingPosition[i])); //add piecemoves
            }

            return horses.ToArray();
        }

        private ChessPiece[] CreateBishops(PieceColor color, string[] startingPosition)
        {
            List<ChessPiece> bishops = new List<ChessPiece>();

            for (int i = 0; i < 2; i++)
            {
                bishops.Add(new ChessPiece(PieceName.Bishop, color, new PieceMoves[] { PieceMoves.Diagonal }, startingPosition[i]));
            }

            return bishops.ToArray();
        }

        public ChessPiece[] CreateRooks(PieceColor color, string[] startingPosition)
        {
            List<ChessPiece> rooks = new List<ChessPiece>();

            for (int i = 0; i < 2; i++)
            {
                rooks.Add(new ChessPiece(PieceName.Rook, color, new PieceMoves[] { PieceMoves.Horizontal, PieceMoves.Vertical, PieceMoves.SmallCastling, PieceMoves.BigCastling }, startingPosition[i]));
            }

            return rooks.ToArray();
        }

        public ChessPiece CreateQueen(PieceColor color, string startingPosition)
        {
            return new ChessPiece(PieceName.Queen, color, new PieceMoves[] { PieceMoves.All }, startingPosition);
        }

        public ChessPiece CreateKing(PieceColor color, string startingPosition)
        {
            return new ChessPiece(PieceName.King, color, new PieceMoves[] { PieceMoves.SingleSquare, PieceMoves.SmallCastling, PieceMoves.BigCastling }, startingPosition);
        }

        #endregion
    }
}
