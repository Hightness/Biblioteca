   M S B A M L   `   `   `  ����E  ABiblioteca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Biblioteca
Biblioteca  5   	   ;,clr-namespace:Biblioteca;assembly=Biblioteca
Biblioteca  5   	       Biblioteca.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Biblioteca     5   	   ?local1,clr-namespace:Biblioteca;assembly=Biblioteca     5   	   -   5          �Name$  window��5   E    � Title$ 
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      ��  �� Orientation$ 
Horizontal=�6   ��6*   �� *ActualWidth+ �� ElementName$ window�� �� Mode$ OneWay=���6i   �� *ActualHeight+$ window��$ OneWay=�.+�5   
   �� $ Vertical=�6   $��0,0,0,50q�6-   ��6?   �� *ActualHeight+$ window��$ OneWay=�.+�5      �� $ 
Horizontal=�6   .+�5      o� $��20��6   $	��132��6%   $
��Left=�61   .@�5      m� $��Modifica��6   $	��132��62   .@�5      �� -   5         ��Name$ btnAggiungi��5   !   $��Aggiungi��67   $��30��6J   $	��132��6V   �� 5      -   5        $ btnModifica��5   !   {�.  $��Modifica��6I   $��30��6\   $	��132��6h   �� 5      -   5        $ 
btnElimina��5   !   {�.  $��Elimina��6H   $��30��6Z   $	��132��6f   5      5      o� 5      $��20��6   $	��132��6%   .@�5      m� $��Struttura B.��6   $	��132��66   .@�5      �� -   5        $ Generi��5   3   {�.  $��Aggiungi Genere��6D   $��30��6^   $	��132��6j   �� 5      -   5        $ Scaffali��5   3   {�.  $��Aggiungi Struttura��6F   $��30��6c   $	��132��6o   �� 5      -   5         ��Name$ strutturaSelezionata��5   "   $	��132��6@   6L   5      5      5      R� 5      -   5         R�Name$ ContenitoreGeneri��5   Y   $��0,0,50,0q�6   $��
10,10,10,0q�6)   $
��Left=�6>   $��Stretch=�6�   $	��484��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   ���	#FFFF7070���	#FF517070���	#FF510000$��2q�6F  ��6t   �� *ActualHeight+$ window��$ OneWay=�	 � 	Resources	 5      
 �� 
TargetType �� Property �� Value��%3  'Q�       �� 5       "
 Q�6   .�5!      ��  � �� 5"      �� 5#   "   .R�5$   &   �� $	��400��61   $
��Left=�6=   .+�5%   *   �� $��15,15,-0.4,0q�60   $��42��6F   $	��200��6R   $��Center=�6r   $
��Left=�6�   $��20(�6�   ��6^   �� 6�   5&   '   5'   #   5)      5*      5+      5,      5-      � 5.   
   -	   5         �Name$
 grid��5.      $��-25,20,0,50q�6   $	��Top=�62   ��6J   �� *ActualHeight+$ window��$ OneWay=�.+�5/      �� -
   5         ��Name$
 Info��5/      $��0q�6%   ���	#7FFF7070$��2q�6G    �� View 50      �� 51      .P�52      �� $��autore��6)    �� Width$	 100��6e    �� DisplayMemberBinding 69   �� *
Tag.Autore+6e   �� 53      $��
numero pag��6)   $ 50��6h    6=   �� *	Tag.Num_P+6h   �� 54      $��titolo��6)   $	 120��6e    69   �� *
Tag.Titolo+6e   55      58      59      5:      5;      