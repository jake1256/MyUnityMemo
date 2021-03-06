u s i n g   U n i t y E n g i n e ; 
 u s i n g   S y s t e m . C o l l e c t i o n s ; 

/**
 * 車動かす時はこんな感じ。ホイールをバインドする
 */
 
 p u b l i c   c l a s s   C a r C o n t r o l l e r   :   M o n o B e h a v i o u r   { 
 	 
 	 p u b l i c   W h e e l C o l l i d e r   w c F r o n t L e f t ; 
 	 p u b l i c   W h e e l C o l l i d e r   w c F r o n t R i g h t ; 
 	 p u b l i c   W h e e l C o l l i d e r   w c R e a r L e f t ; 
 	 p u b l i c   W h e e l C o l l i d e r   w c R e a r R i g h t ; 
 
 	 
 	 p u b l i c   V e c t o r 3   c e n t e r O f M a s s ; 
 	 p u b l i c   f l o a t   e n g i n e P o w e r   =   3 0 f ; 
 	 p u b l i c   f l o a t   b r a k e P o w e r   =   8 f ; 
 	 p u b l i c   f l o a t   s t e e r A n g l e M a x   =   2 0 f ; 
 	 
 	 p r i v a t e   b o o l   i s A c c e l O n ; 
 	 p r i v a t e   b o o l   i s F o w a r d ; 
 	 p r i v a t e   b o o l   i s B a c k ; 
 	 p r i v a t e   b o o l   i s L e f t ; 
 	 p r i v a t e   b o o l   i s R i g h t ; 
 	 
 	 p r i v a t e   R e c t   g o B t n R e c t ; 
 	 p r i v a t e   R e c t   b a c k B t n R e c t ; 
 	 p r i v a t e   R e c t   l e f t B t n R e c t ; 
 	 p r i v a t e   R e c t   r i g h t B t n R e c t ; 
 	 
 	 p u b l i c   J o y s t i c k   j o y s t i c k ; 
 	 p u b l i c   J o y s t i c k   j o y s t i c k 2 ; 
 	 p r i v a t e   s t r i n g   s t r ; 
 	 
 	 v o i d   S t a r t   ( )   { 
 	 	 r i g i d b o d y . c e n t e r O f M a s s   =   c e n t e r O f M a s s ; 
 	 	 g o B t n R e c t   =   n e w   R e c t ( 5 5 0 ,   1 0 0   ,   1 0 0   ,   1 0 0 ) ; 
 	 	 b a c k B t n R e c t   =   n e w   R e c t ( 5 5 0   ,   2 0 0   ,   1 0 0   ,   1 0 0 ) ; 
 	 	 l e f t B t n R e c t   =   n e w   R e c t ( 0 ,   1 0 0 ,   1 0 0 ,   1 0 0 ) ; 
 	 	 r i g h t B t n R e c t   =   n e w   R e c t ( 1 0 0 ,   1 0 0 ,   1 0 0 ,   1 0 0 ) ; 
 	 	 s t r   =   " " ; 
 	 	 G a m e O b j e c t   g   =   G a m e O b j e c t . F i n d ( " J o y s t i c k " ) ; 
 	 	 G a m e O b j e c t   g 2   =   G a m e O b j e c t . F i n d ( " J o y s t i c k 2 " ) ; 
 	 	 j o y s t i c k   =   g . G e t C o m p o n e n t < J o y s t i c k > ( ) ; 
 	 	 j o y s t i c k 2   =   g 2 . G e t C o m p o n e n t < J o y s t i c k > ( ) ; 
 	 	 / / j o y s t i c k   =   ( J o y s t i c k ) G a m e O b j e c t . F i n d ( " J o y S t i c k e r " ) ; 
 	 } 
 	 
 	 v o i d   F i x e d U p d a t e   ( )   { 
 	 	 s t r   =   " l e f t [ "   +   j o y s t i c k . p o s i t i o n   +   " ]   r i g h t [ "   +   j o y s t i c k 2 . p o s i t i o n   +   " ] " ; 
 	 	 / / V e c t o r 3   v e l o c i t y   =   V e c t o r 3 ( j o y s t i c k . p o s i t i o n . x ,   0 ,   j o y s t i c k . p o s i t i o n . y ) ; 
         	 i f   ( I n p u t . G e t K e y ( K e y C o d e . W )   | |   i s F o w a r d   | |   j o y s t i c k . p o s i t i o n . y   >   0 . 0 1 )   { 
 	 	 	 g o F o r w a r d ( ) ; 
 	 	 }   e l s e   i f   ( I n p u t . G e t K e y ( K e y C o d e . S )   | |   i s B a c k   | |   j o y s t i c k . p o s i t i o n . y   <   - 0 . 0 1 )   { 
 	 	 	 g o B a c k ( ) ; 
 	 	 }   e l s e   { 
 	 	 	 a c c e l O f f ( ) ; 
 	 	 } 
 	 	 
 	 	 f l o a t   h   =   0 ; 
 	 	 i f ( j o y s t i c k 2 . p o s i t i o n . x   <   - 0 . 0 1 ) { 
 	 	 	 h   =   1   +   j o y s t i c k 2 . p o s i t i o n . x ; 
 	 	 } 
 	 	 e l s e   i f ( j o y s t i c k 2 . p o s i t i o n . x   >   0 . 0 1 ) { 
 	 	 	 h   =   - 1   +   j o y s t i c k 2 . p o s i t i o n . x ; 
 	 	 } 
 	 	 
 	 	 
 	 	 m o v e O u t ( h ) ; 
 	 } 
 	 
 / * 	 v o i d   F i x e d U p d a t e   ( )   { 
 	 	 i n t   c o u n t   =   I n p u t . t o u c h C o u n t ; 
 	 	 
 	 	 D e b u g . L o g ( " t o u c h   c o u n t   = =   "   +   c o u n t ) ; 
 	 	 i f ( c o u n t   = =   0 ) { 
 	 	 	 / / t o u c h i n g   =   f a l s e ; 
 	 	 	 / / t o u c h I d   =   - 1 ; 
 	 	 	 i s F o w a r d   =   f a l s e ; 
 	 	 	 i s B a c k   =   f a l s e ; 
 	 	 	 i s L e f t   =   f a l s e ; 
 	 	 	 i s R i g h t   =   f a l s e ; 
 	 	 } e l s e { 
 	 	 	 f o r ( i n t   i   =   0   ;   i   <   c o u n t   ;   i + + ) { 
 	 	 	 	 T o u c h   t o u c h   =   I n p u t . G e t T o u c h ( i ) ; 
 	 	 	 	 
 	 	 	 	 D e b u g . L o g ( " t o u c h [ " + i + " ] "   +   t o u c h . p o s i t i o n ) ; 
 	 	 	 	 
 	 	 	 	 i f ( g o B t n R e c t . C o n t a i n s ( t o u c h . p o s i t i o n ) ) { 
 	 	 	 	 	 i s F o w a r d   =   t r u e ; 
 	 	 	 	 } e l s e { 
 	 	 	 	 	 i s F o w a r d   =   f a l s e ; 
 	 	 	 	 } 
 	 	 	 	 
 	 	 	 	 i f ( b a c k B t n R e c t . C o n t a i n s ( t o u c h . p o s i t i o n ) ) { 
 	 	 	 	 	 i s B a c k   =   t r u e ; 
 	 	 	 	 } e l s e { 
 	 	 	 	 	 i s B a c k   =   f a l s e ; 
 	 	 	 	 } 
 	 	 	 	 i f ( l e f t B t n R e c t . C o n t a i n s ( t o u c h . p o s i t i o n ) ) { 
 	 	 	 	 	 i s L e f t   =   t r u e ; 
 	 	 	 	 } e l s e { 
 	 	 	 	 	 i s L e f t   =   f a l s e ; 
 	 	 	 	 } 
 	 	 	 	 i f ( r i g h t B t n R e c t . C o n t a i n s ( t o u c h . p o s i t i o n ) ) { 
 	 	 	 	 	 i s R i g h t   =   t r u e ; 
 	 	 	 	 } e l s e { 
 	 	 	 	 	 i s R i g h t   =   f a l s e ; 
 	 	 	 	 } 
 	 	 	 } 
 	 	 } 
 	 	 
 	 	 i f   ( I n p u t . G e t K e y ( K e y C o d e . W )   | |   i s F o w a r d )   { 
 	 	 	 g o F o r w a r d ( ) ; 
 	 	 }   e l s e   i f   ( I n p u t . G e t K e y ( K e y C o d e . S )   | |   i s B a c k )   { 
 	 	 	 g o B a c k ( ) ; 
 	 	 }   e l s e   { 
 	 	 	 a c c e l O f f ( ) ; 
 	 	 } 
 	 	 
 	 	 
 
 	 	 f l o a t   h   =   I n p u t . G e t A x i s ( " H o r i z o n t a l " )   +   - I n p u t . a c c e l e r a t i o n . y ; 
 	 	 
 	 	 i f ( i s L e f t ) { 
 	 	 	 h   =   - 1   +   - I n p u t . a c c e l e r a t i o n . y ; 
 	 	 } e l s e 
 	 	 i f ( i s R i g h t ) { 
 	 	 	 h   =   1   +   - I n p u t . a c c e l e r a t i o n . y ; 
 	 	 } e l s e { 
 	 	 	 # i f   U N I T Y _ I P H O N E   | |   U N I T Y _ A N D R O I D 
 	 	 	 / / h   =   0 ; 
 	 	 	 # e n d i f 
 	 	 } 
 	 	 
 	 } 
 * / 
 	 p r i v a t e   v o i d   g o F o r w a r d ( ) { 
 	 	 i s A c c e l O n   =   t r u e ; 
 	 	 f l o a t   t o r u e   =   e n g i n e P o w e r ; 
 	 	 f l o a t   t o r u e I d l e   =   e n g i n e P o w e r   *   0 . 2 f ; 
 	 	 w c F r o n t L e f t . m o t o r T o r q u e   =   ( w c F r o n t L e f t . i s G r o u n d e d )   ?   t o r u e   :   t o r u e I d l e ; 
 	 	 w c F r o n t R i g h t . m o t o r T o r q u e   =   ( w c F r o n t R i g h t . i s G r o u n d e d )   ?   t o r u e   :   t o r u e I d l e ; 
 	 	 w c R e a r L e f t . m o t o r T o r q u e   =   ( w c R e a r L e f t . i s G r o u n d e d )   ?   t o r u e   :   t o r u e I d l e ; 
 	 	 w c R e a r R i g h t . m o t o r T o r q u e   =   ( w c R e a r R i g h t . i s G r o u n d e d )   ?   t o r u e   :   t o r u e I d l e ; 
 	 } 
 	 
 	 p r i v a t e   v o i d   g o B a c k ( ) { 
 	 	 i s A c c e l O n   =   t r u e ; 
 	 	 f l o a t   t o r u e   =   e n g i n e P o w e r   *   - 1 . 0 f ; 
 	 	 f l o a t   t o r u e I d l e   =   e n g i n e P o w e r   *   - 0 . 2 f ; 
 	 	 w c F r o n t L e f t . m o t o r T o r q u e   =   ( w c F r o n t L e f t . i s G r o u n d e d )   ?   t o r u e   :   t o r u e I d l e ; 
 	 	 w c F r o n t R i g h t . m o t o r T o r q u e   =   ( w c F r o n t R i g h t . i s G r o u n d e d )   ?   t o r u e   :   t o r u e I d l e ; 
 	 	 w c R e a r L e f t . m o t o r T o r q u e   =   ( w c R e a r L e f t . i s G r o u n d e d )   ?   t o r u e   :   t o r u e I d l e ; 
 	 	 w c R e a r R i g h t . m o t o r T o r q u e   =   ( w c R e a r R i g h t . i s G r o u n d e d )   ?   t o r u e   :   t o r u e I d l e ; 
 	 } 
 	 
 	 p r i v a t e   v o i d   a c c e l O f f ( ) { 
 	 	 i s A c c e l O n   =   f a l s e ; 
 	 	 w c F r o n t L e f t . m o t o r T o r q u e   =   0 ; 
 	 	 w c F r o n t R i g h t . m o t o r T o r q u e   =   0 ; 
 	 	 w c R e a r L e f t . m o t o r T o r q u e   =   0 ; 
 	 	 w c R e a r R i g h t . m o t o r T o r q u e   =   0 ; 
 	 	 	 
 	 	 w c F r o n t L e f t . b r a k e T o r q u e   =   b r a k e P o w e r ; 
 	 	 w c F r o n t R i g h t . b r a k e T o r q u e   =   b r a k e P o w e r ; 
 	 	 w c R e a r L e f t . b r a k e T o r q u e   =   b r a k e P o w e r ; 
 	 	 w c R e a r R i g h t . b r a k e T o r q u e   =   b r a k e P o w e r ; 
 	 } 
 	 
 	 p r i v a t e   v o i d   m o v e O u t ( f l o a t   h ) { 
 	 	 f l o a t   a n g l e   =   h   *   s t e e r A n g l e M a x ; 
 	 	 w c F r o n t L e f t . s t e e r A n g l e   =   a n g l e ; 
 	 	 w c F r o n t R i g h t . s t e e r A n g l e   =   a n g l e ; 
 	 } 
 	 
 	 p u b l i c   b o o l   I s A c c e l O n   ( )   { 
 	 	 r e t u r n   i s A c c e l O n ; 
 	 } 
 	 
 	 p u b l i c   b o o l   I s W h e e l G r o u n d e d   ( )   { 
 	 	 r e t u r n   w c F r o n t L e f t . i s G r o u n d e d   | |   w c F r o n t R i g h t . i s G r o u n d e d   
 	 	 	 | |   w c R e a r L e f t . i s G r o u n d e d   | |   w c R e a r R i g h t . i s G r o u n d e d ; 
 	 } 
 	 
 	 p u b l i c   f l o a t   G e t E n g i n e R e v o l u t i o n   ( )   { 
 	 	 r e t u r n   M a t h f . A b s ( w c F r o n t L e f t . r p m   +   w c F r o n t R i g h t . r p m   +   w c R e a r L e f t . r p m   +   w c R e a r R i g h t . r p m )   *   0 . 2 5 f ; 
 	 } 
 	 
 	 # i f   U N I T Y _ I P H O N E   | |   U N I T Y _ A N D R O I D 
 	 v o i d   O n G U I   ( )   { 
 	 	 / / i s F o w a r d   =   G U I . R e p e a t B u t t o n ( n e w   R e c t ( S c r e e n . w i d t h   -   8 0 ,   S c r e e n . h e i g h t   -   1 6 0 ,   8 0 ,   7 0 ) ,   " G O " ) ; 
 	 	 / / i s B a c k   =   G U I . R e p e a t B u t t o n ( n e w   R e c t ( S c r e e n . w i d t h   -   8 0 ,   S c r e e n . h e i g h t   -   8 0 ,   8 0 ,   7 0 ) ,   " B A C K " ) ; 
 	 	 
 	 	 G U I . L a b e l ( n e w   R e c t ( 0   ,   0   ,   1 0 0   ,   1 0 0 )   ,   s t r ) ; 
 	 } 
 # e n d i f 
 } 
 
