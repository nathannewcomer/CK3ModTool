grammar Paradox;

// parser
file : pair+ ;

pair : IDENTIFIER '=' value ;

value : IDENTIFIER | NUMBER | object ;

object : IDENTIFIER? '{' contents '}' ;

contents : (pair* object*) | list ;

list : IDENTIFIER+ | NUMBER ;

// lexer
IDENTIFIER : [-.'"@:_a-zA-Z0-9]+ ;

NUMBER : '-'? INT ('.' [0-9] +)? ;

fragment INT : '0' | [1-9] [0-9]* ;

WHITESPACE : [ \t\r\n]+ -> skip ;

COMMENT : '#' ~[\r\n]* -> skip ;

// UTF-8 byte order mark - text files in CKIII (at least on Windows) have this so ignore it
BOM : [\u00EF\u00BB\u00BF]+ -> skip ;