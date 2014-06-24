u s i n g   U n i t y E n g i n e ; 
 u s i n g   S y s t e m . C o l l e c t i o n s ; 

/**
 * タイヤがコロコロ回るやつ
 */
 
 p u b l i c   c l a s s   W h e e l   :   M o n o B e h a v i o u r   { 
 
 	 p u b l i c   W h e e l C o l l i d e r   w h e e l C o l l i d e r ; 
 	 
 	 p r i v a t e   f l o a t   r o t a t i o n ; 
 	 p r i v a t e   W h e e l H i t   h i t ; 
 
 	 v o i d   U p d a t e   ( )   { 
 	 	 V e c t o r 3   c o l l i d e r C e n t e r   =   w h e e l C o l l i d e r . t r a n s f o r m . T r a n s f o r m P o i n t ( w h e e l C o l l i d e r . c e n t e r ) ; 
 	 	 
 	 	 i f   ( w h e e l C o l l i d e r . G e t G r o u n d H i t ( o u t   h i t ) )   { 
 	 	 	 t r a n s f o r m . p o s i t i o n   =   h i t . p o i n t   +   ( w h e e l C o l l i d e r . t r a n s f o r m . u p   *   w h e e l C o l l i d e r . r a d i u s ) ; 
 	 	 }   e l s e   { 
 	 	 	 t r a n s f o r m . p o s i t i o n   =   c o l l i d e r C e n t e r   -   ( w h e e l C o l l i d e r . t r a n s f o r m . u p   *   w h e e l C o l l i d e r . s u s p e n s i o n D i s t a n c e ) ; 
 	 	 } 
 	 	 t r a n s f o r m . r o t a t i o n   =   w h e e l C o l l i d e r . t r a n s f o r m . r o t a t i o n   *   Q u a t e r n i o n . E u l e r ( r o t a t i o n ,   w h e e l C o l l i d e r . s t e e r A n g l e ,   0 ) ; 
 	 	 r o t a t i o n   + =   w h e e l C o l l i d e r . r p m   *   ( 3 6 0   /   6 0 )   *   T i m e . d e l t a T i m e ; 
 	 } 
 } 
 
