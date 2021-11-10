//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Paradox.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class ParadoxParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, IDENTIFIER=4, NUMBER=5, WHITESPACE=6, COMMENT=7, 
		BOM=8;
	public const int
		RULE_file = 0, RULE_pair = 1, RULE_value = 2, RULE_object = 3, RULE_contents = 4, 
		RULE_list = 5;
	public static readonly string[] ruleNames = {
		"file", "pair", "value", "object", "contents", "list"
	};

	private static readonly string[] _LiteralNames = {
		null, "'='", "'{'", "'}'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, "IDENTIFIER", "NUMBER", "WHITESPACE", "COMMENT", 
		"BOM"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Paradox.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static ParadoxParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public ParadoxParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public ParadoxParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class FileContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public PairContext[] pair() {
			return GetRuleContexts<PairContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public PairContext pair(int i) {
			return GetRuleContext<PairContext>(i);
		}
		public FileContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_file; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.EnterFile(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.ExitFile(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IParadoxVisitor<TResult> typedVisitor = visitor as IParadoxVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFile(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FileContext file() {
		FileContext _localctx = new FileContext(Context, State);
		EnterRule(_localctx, 0, RULE_file);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 13;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 12;
				pair();
				}
				}
				State = 15;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==IDENTIFIER );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PairContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER() { return GetToken(ParadoxParser.IDENTIFIER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value() {
			return GetRuleContext<ValueContext>(0);
		}
		public PairContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_pair; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.EnterPair(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.ExitPair(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IParadoxVisitor<TResult> typedVisitor = visitor as IParadoxVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPair(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PairContext pair() {
		PairContext _localctx = new PairContext(Context, State);
		EnterRule(_localctx, 2, RULE_pair);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 17;
			Match(IDENTIFIER);
			State = 18;
			Match(T__0);
			State = 19;
			value();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ValueContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER() { return GetToken(ParadoxParser.IDENTIFIER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NUMBER() { return GetToken(ParadoxParser.NUMBER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ObjectContext @object() {
			return GetRuleContext<ObjectContext>(0);
		}
		public ValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_value; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.EnterValue(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.ExitValue(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IParadoxVisitor<TResult> typedVisitor = visitor as IParadoxVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitValue(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ValueContext value() {
		ValueContext _localctx = new ValueContext(Context, State);
		EnterRule(_localctx, 4, RULE_value);
		try {
			State = 24;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,1,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 21;
				Match(IDENTIFIER);
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 22;
				Match(NUMBER);
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 23;
				@object();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ObjectContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ContentsContext contents() {
			return GetRuleContext<ContentsContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER() { return GetToken(ParadoxParser.IDENTIFIER, 0); }
		public ObjectContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_object; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.EnterObject(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.ExitObject(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IParadoxVisitor<TResult> typedVisitor = visitor as IParadoxVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitObject(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ObjectContext @object() {
		ObjectContext _localctx = new ObjectContext(Context, State);
		EnterRule(_localctx, 6, RULE_object);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 27;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==IDENTIFIER) {
				{
				State = 26;
				Match(IDENTIFIER);
				}
			}

			State = 29;
			Match(T__1);
			State = 30;
			contents();
			State = 31;
			Match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ContentsContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public PairContext[] pair() {
			return GetRuleContexts<PairContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public PairContext pair(int i) {
			return GetRuleContext<PairContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ListContext list() {
			return GetRuleContext<ListContext>(0);
		}
		public ContentsContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_contents; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.EnterContents(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.ExitContents(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IParadoxVisitor<TResult> typedVisitor = visitor as IParadoxVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitContents(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ContentsContext contents() {
		ContentsContext _localctx = new ContentsContext(Context, State);
		EnterRule(_localctx, 8, RULE_contents);
		int _la;
		try {
			State = 40;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,4,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 36;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==IDENTIFIER) {
					{
					{
					State = 33;
					pair();
					}
					}
					State = 38;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 39;
				list();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ListContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] IDENTIFIER() { return GetTokens(ParadoxParser.IDENTIFIER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER(int i) {
			return GetToken(ParadoxParser.IDENTIFIER, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] NUMBER() { return GetTokens(ParadoxParser.NUMBER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NUMBER(int i) {
			return GetToken(ParadoxParser.NUMBER, i);
		}
		public ListContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_list; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.EnterList(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IParadoxListener typedListener = listener as IParadoxListener;
			if (typedListener != null) typedListener.ExitList(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IParadoxVisitor<TResult> typedVisitor = visitor as IParadoxVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitList(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ListContext list() {
		ListContext _localctx = new ListContext(Context, State);
		EnterRule(_localctx, 10, RULE_list);
		int _la;
		try {
			State = 52;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case IDENTIFIER:
				EnterOuterAlt(_localctx, 1);
				{
				State = 43;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				do {
					{
					{
					State = 42;
					Match(IDENTIFIER);
					}
					}
					State = 45;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				} while ( _la==IDENTIFIER );
				}
				break;
			case NUMBER:
				EnterOuterAlt(_localctx, 2);
				{
				State = 48;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				do {
					{
					{
					State = 47;
					Match(NUMBER);
					}
					}
					State = 50;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				} while ( _la==NUMBER );
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\n', '\x39', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x3', '\x2', '\x6', '\x2', 
		'\x10', '\n', '\x2', '\r', '\x2', '\xE', '\x2', '\x11', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x5', '\x4', '\x1B', '\n', '\x4', '\x3', '\x5', '\x5', 
		'\x5', '\x1E', '\n', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x6', '\a', '\x6', '%', '\n', '\x6', '\f', '\x6', 
		'\xE', '\x6', '(', '\v', '\x6', '\x3', '\x6', '\x5', '\x6', '+', '\n', 
		'\x6', '\x3', '\a', '\x6', '\a', '.', '\n', '\a', '\r', '\a', '\xE', '\a', 
		'/', '\x3', '\a', '\x6', '\a', '\x33', '\n', '\a', '\r', '\a', '\xE', 
		'\a', '\x34', '\x5', '\a', '\x37', '\n', '\a', '\x3', '\a', '\x2', '\x2', 
		'\b', '\x2', '\x4', '\x6', '\b', '\n', '\f', '\x2', '\x2', '\x2', ';', 
		'\x2', '\xF', '\x3', '\x2', '\x2', '\x2', '\x4', '\x13', '\x3', '\x2', 
		'\x2', '\x2', '\x6', '\x1A', '\x3', '\x2', '\x2', '\x2', '\b', '\x1D', 
		'\x3', '\x2', '\x2', '\x2', '\n', '*', '\x3', '\x2', '\x2', '\x2', '\f', 
		'\x36', '\x3', '\x2', '\x2', '\x2', '\xE', '\x10', '\x5', '\x4', '\x3', 
		'\x2', '\xF', '\xE', '\x3', '\x2', '\x2', '\x2', '\x10', '\x11', '\x3', 
		'\x2', '\x2', '\x2', '\x11', '\xF', '\x3', '\x2', '\x2', '\x2', '\x11', 
		'\x12', '\x3', '\x2', '\x2', '\x2', '\x12', '\x3', '\x3', '\x2', '\x2', 
		'\x2', '\x13', '\x14', '\a', '\x6', '\x2', '\x2', '\x14', '\x15', '\a', 
		'\x3', '\x2', '\x2', '\x15', '\x16', '\x5', '\x6', '\x4', '\x2', '\x16', 
		'\x5', '\x3', '\x2', '\x2', '\x2', '\x17', '\x1B', '\a', '\x6', '\x2', 
		'\x2', '\x18', '\x1B', '\a', '\a', '\x2', '\x2', '\x19', '\x1B', '\x5', 
		'\b', '\x5', '\x2', '\x1A', '\x17', '\x3', '\x2', '\x2', '\x2', '\x1A', 
		'\x18', '\x3', '\x2', '\x2', '\x2', '\x1A', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x1B', '\a', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x1E', '\a', 
		'\x6', '\x2', '\x2', '\x1D', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'\x1E', '\x3', '\x2', '\x2', '\x2', '\x1E', '\x1F', '\x3', '\x2', '\x2', 
		'\x2', '\x1F', ' ', '\a', '\x4', '\x2', '\x2', ' ', '!', '\x5', '\n', 
		'\x6', '\x2', '!', '\"', '\a', '\x5', '\x2', '\x2', '\"', '\t', '\x3', 
		'\x2', '\x2', '\x2', '#', '%', '\x5', '\x4', '\x3', '\x2', '$', '#', '\x3', 
		'\x2', '\x2', '\x2', '%', '(', '\x3', '\x2', '\x2', '\x2', '&', '$', '\x3', 
		'\x2', '\x2', '\x2', '&', '\'', '\x3', '\x2', '\x2', '\x2', '\'', '+', 
		'\x3', '\x2', '\x2', '\x2', '(', '&', '\x3', '\x2', '\x2', '\x2', ')', 
		'+', '\x5', '\f', '\a', '\x2', '*', '&', '\x3', '\x2', '\x2', '\x2', '*', 
		')', '\x3', '\x2', '\x2', '\x2', '+', '\v', '\x3', '\x2', '\x2', '\x2', 
		',', '.', '\a', '\x6', '\x2', '\x2', '-', ',', '\x3', '\x2', '\x2', '\x2', 
		'.', '/', '\x3', '\x2', '\x2', '\x2', '/', '-', '\x3', '\x2', '\x2', '\x2', 
		'/', '\x30', '\x3', '\x2', '\x2', '\x2', '\x30', '\x37', '\x3', '\x2', 
		'\x2', '\x2', '\x31', '\x33', '\a', '\a', '\x2', '\x2', '\x32', '\x31', 
		'\x3', '\x2', '\x2', '\x2', '\x33', '\x34', '\x3', '\x2', '\x2', '\x2', 
		'\x34', '\x32', '\x3', '\x2', '\x2', '\x2', '\x34', '\x35', '\x3', '\x2', 
		'\x2', '\x2', '\x35', '\x37', '\x3', '\x2', '\x2', '\x2', '\x36', '-', 
		'\x3', '\x2', '\x2', '\x2', '\x36', '\x32', '\x3', '\x2', '\x2', '\x2', 
		'\x37', '\r', '\x3', '\x2', '\x2', '\x2', '\n', '\x11', '\x1A', '\x1D', 
		'&', '*', '/', '\x34', '\x36',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
