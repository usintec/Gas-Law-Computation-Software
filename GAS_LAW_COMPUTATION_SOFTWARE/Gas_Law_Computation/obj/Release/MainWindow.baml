   M S B A M L   `   `   `  ���� N  JGas_Law_Computation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Gas_Law_ComputationGas_Law_Computation  $    Gas_Law_Computation.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Gas_Law_Computation     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions    � Title$  Gas Law Computation��$��721.846��$��1044.231�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� � 	Resources ��%    .��� -    �Name$ grid_application��$��0,0,2,-4q� � ColumnDefinitions �� $	��12* ��� $	��19* ��� $	��27* ��� $
��166* ��� $	��80* ��� $	��79* ��� $
��190* ��� $
��158* ��� $	��93* ��� $
��382* ��� $
��383* �.+�� -   $ grid_panel_for_rectangle��$��11��$	��148��$	��Top=� �� $
��437* ��� $
��596* �����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black��	 � Offset$	 0Q�� $ White��$	 1Q�.+��� -   
 ��Name$
 rectangle_bg��$��146.154��
���   �$��0�� K� ZIndex$ 11�� J� Opacity$	 0.9Q�$��2��$��0,1,0,0.846q����� $ 0.5,1&� � MappingMode$ RelativeToBoundingBox=�$ 0.5,0&�.��� $ 	#FFD85C9A��$	 0Q�� $ 	#FF040C30��$	 1Q�� -   $ grid_panel_for_path��$��11��$	��148��$	��Top=� �� $
��916* ��� $
��119* �.+�F� ���к��	v��	���	#FFB8B8E0$
��Left=�$��1��$��167.154,73.5,0,73.5q� �� Stretch$
 Fill=�
���   �$��1��F� -    F�Name$ top_bg����������i��;?�N~��\[~=�N~��\[~=1�`\[~=��B\[~=d.%�\[~=d.%`y�5;� �x0��5�ZF�-�.3#&n�
Z�N$��	Sw�s�Qo������"j����"j��:�Y��`fK��X
���i��;?d.%	$��146.83��$
 Fill=����	#FF26E2F5$��3��$��-0.5,0.585,0,0.585q�$	 0.9Q�$��2�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Opacity$	 0.2Q�   ShadowDepth$ 2Q����� $ 0.5,1&�$ RelativeToBoundingBox=�$ 0.5,0&�.��� $ 	#FF79E4D5��� $ 	#FFFFFDE4��$	 0.406Q�� $ 	#FF8CB6CF��$	 0.699Q��� -    ��Name$ label��$"��GAS LAW COMPUTATION SOFTWARE��$��225,72.5,41.5,27.585q�$��29.333(� J� RenderTransformOrigin$ 
0.823,0.31&�$��Arial Black)�$��2������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFD4D074��$	 0Q�� $ White��$	 1Q�c� -    c�Name$ toolBar_menu��$��12.763,153,10,0q�$��5��$��49��$	��Top=�$��6����Z� .@�o� -    o�Name$
 menu��$��572.5��$
��Left=�$��Center=�$��0,2.538q����� $ 0.5,1&�$ 0.5,0&�.��� $ Black��$	 0Q�� $ 	#FF1540B6��$	 1Q�.@�m� -	    m�Name$ mnu_home��$
��Home��$��24(�
���������Z� m� -
   $ mnu_boyles_law��$��
Boyles Law��$��24(�
���������Z� .@�m� -   $ sbm_boyles_p1��$��Compute Pressure (P1)��m� -   $ sbm_boyles_volume_v1��$��Compute Volume (V1)��m� -   $ sbm_boyles_p2��$��Compute Pressure (P2)��m� -   $ sbm_boyles_volumes_v2��$��Compute Volume (V2)��m� -   $��smb_boyles_automation��$��
Automation��m� -   $ mnu_charles_law��$��Charles Law��$��24(�
�������.@�m� -   $ sbm_charles_t1��$��Compute Temperature (T1)��m� -   $ sbm_charles_v1��$��Compute Volume (V1)��m� -   $ sbm_charles_t2��$��Compute Temperature (T2)��m� -   $ sbm_charles_v2��$��Compute Volume (V2)��m� -   $ sbm_charles_automation��$��
Automation��m� -   $ mnu_gas_equation��$��Gas Equation��$��24(�
�������.@�m� -   $ sbm_gas_pressure��$��Compute Pressure ��m� -   $ sbm_gas_volume��$��Compute Volume��m� -   $ sbm_gas_mole��$��Compute Mole��m� -   $ sbm_gas_temperature��$��Compute Temperature��m� -   $ mnu_help��$
��Help��$��24(�
�������� -   $ grid_computation_bg��$��10��$��2.19,216,10,88.038q�$��1������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF225CC1��$	 0.096Q�� $ 	#FF92E6B4��$	 1Q�.+��� -    ��Name$ stack_information��$��82.55��
���   �$	��Top=�.+��� -    ��Name$ txt_bl_formular_numerator��$
��Wrap=�$��44.46��
�������$��18.667(�$��462.142,0,243.142,0q�$��303.074��$
��Bold"� �� TextEffects z�  z� PositionStart$ 1�� z� PositionCount$ 1�� z� 	Transform V� .~��� �� �� T�  T� Y$ 12Q�z� $ 6��$ 1�� V� .~��� �� �� T� $ 12Q�z� $ 8��$ 1�� V� .~��� �� �� T� $ 12Q� � BindingGroup &   System.Windows.Data.BindingGroup  �� -   $
 rect_division��
�������$	��3.5��
���   �$��0,0,436.5,0q�$ 0.5,0.5&�$��Right=�$��54.358��$y�Hidden=�z�V� .~���   �� ScaleY$  -1Q��� �� T� �� -    $! txt_bl_formular_denominator��$
��Wrap=�$��26.46��$��	0,0,423,0q�
���   ����	#FFF9F9F9$��Right=�$��45.358��$��18.667(�$
��Bold"� z� $ 1��$ 1�� V� .~��� �� �� T� $ 12Q��� -!   $ txt_block_title��$
��Wrap=�
! �� Top$	! 1.5��" �� Left$" 103.5��$��422.488,82.55,304,0q�$��28.346��$	��Top=��� -"   $ txt_block_x_axis��$
��Wrap=�$ 
1.12,14.96&�$" 107.021��$! 234.04��$��466.358,0,378,8.962q�$��20.846��$��Bottom=��� -#   $ txt_block_y_axis��$
��Wrap=�$ 0.578,15.332&�$! 133.777��$��347,0,0,130q�$
��Left=�$��66.358��$��22.346��$��Bottom=�# � LayoutTransform# V� .~��� �� �� $ �� Angle$$ 90Q�T� � -$   $ grid_input_data��$��19.5,101.5,0,28q�$
��Left=�$	��322��
���   �$	 0.6Q� �� $��5 ��� $��5 �% � RowDefinitions% �� $��5 ��� $��5 �.+��� -%   & ��Name$& txt_first_parameter��$��0,0,-229.5,-73q�' �� TextWrapping$
' Wrap=�$��1��$��Right=�$
��41.5��$��1��$��Bottom=�$
��76.5��
�������$��3q����	#FF060000$��21.333(��� -&   $& txt_third_parameter��$��0,0,-229.5,-192q�$
' Wrap=�$��1��$��Right=�$
��41.5��$��1��$��Bottom=�$
��76.5��$��21.333(�$��3q����	#FF060000
��������� -'   $& txt_second_parameter��$��0,0,-229.5,-133q�$
' Wrap=�$��1��$��Right=�$
��41.5��$��1��$��Bottom=�$
��76.5��$��21.333(�$��3q����	#FF060000
��������� -(   $ lbl_first_parameter��$�� ��$��-0.097,0,-165.433,-82q�$��49��$��1��$��Bottom=�$��1��
�������$
��Bold"�$��13.333(��� -)   $ lbl_second_parameter��$�� ��$��-0.097,0,-165.433,-142q�$��1��$��46��$��1��$��Bottom=����	#FFFBF9F9$
��Bold"�$��13.333(��� -*   $ lbl_third_parameter��$�� ��$��2.5,0,-171.865,-203.5q�$
��47.5��$��1��$��Bottom=����	#FFF7F7F7$
��Bold"�$��13.333(�$��2���� -+   ( ��Name$( btn_compute��$��COMPUTE��$��0,0,-106,-237.308q�$��1��$��Bottom=�$��35.384��$��1��$��Right=�$��96��$��16(�$
��Bold"�
�������$ 0.474,-0.749&����� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF28BD94��$	 0.365Q�� $ 	#FF4557C7��$	 1Q��� -,   $( btn_clear_all��$��	CLEAR ALL��$��0,0,-288,-237.308q�$��1��$��Bottom=�$��35.384��$��1��$��Right=�$��96��$��16(�$
��Bold"�
�������$ 	0.5,0.511&����� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF28BD94��$	 0.365Q�� $ 	#FF4557C7��$	 1Q��� --   ) ��Name$) cmb_first_parameter��$��0,0,-306.5,-73q�$��1��$��Bottom=�$��1��$��Right=�$
��70.5��$
��41.5���� -.   $) cmb_second_parameter��$��0,0,-306.5,-131.5q�$��1��$��Bottom=�$��1��$��Right=�$
��70.5��$
��41.5���� -/   $) cmb_third_parameter��$��0,0,-306.5,-190q�$��1��$��Bottom=�$��1��$��Right=�$
��70.5��$
��41.5��� -0   $ 
grid_graph��$��0,101.5,350.5,28q�$	 0.8Q�$��Right=�$��289.727��$��Visible=����� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF80DAE8��$	 0.068Q�� $ White��$	 1Q�.+�(� -1   * (�Name$* viewbox_graph��$��
0,12,10,10q�.���� -2   + ��Name$+ chart_border��
�������$��1q�$��272.452��$��300.869��� -3   $ grid_computed_result��$��0,101.5,20.5,28q�
���   �$	 0.6Q�$��Right=�$	��310�� �� $��5 ��� $��5 �% �� $��5 ��� $��5 �.+�&   System.Windows.Controls.DataGrid  -4   ,  Name$, dtg_computed��$��0,0,-287,-226.808q�$��1��$��Right=�$	��285��$��221.808��$��1��$��Bottom=�-   CanUserReorderColumns- .  � -5   . �Name$. 
prb_status��$��13.462��$��Bottom=�$��19.5,0,20.5,1q��� -6   $ txt_bl_help��$
��Wrap=�$
��Left=�$	��Top=�$��19.5,101.5,0,0q�$��976.215��$����Gas Law Computation Software is a software that compute or solve Gas equation, Bolyles law and Charles Law.This software  also performs automational calculation for both Boyles Law and Charlels Law and genrate Line Chart for both because Boyles law and  Charles Law calcuation involves only two variables easier to show on graph unlike the gas equation calculation which involes four variables.
Gas Law Computation Software is intuitive and easy to use.The user is only expected to select the problem to solve from the provided menu and supply the neccessary parameters after which the user should click on compute.
It should however be noted that the user is only expected to supply two parameters when perfoming Boyles Law or Charles Law automational calculation.When performing automation on Boyles Law for example, the first parameter is "Range of Presure" which should be supplied in this format (1-50) where 1 is the starting value and 50 is the ending value giving us the range of pressure to automate.The sofware will automatically compute the range of volume and as such, the user does not need to supply the range of volume. But, the user still need to supply us with the value of volume for any value of pressure within the range supplied.This will be the second parameter which will be supplied in the third textbox in this format (2-3) meaning that when pressure is 2, volume is 3 and the software will use this supplied parameter to generate volume for other values of pressure.��$��16(�$y�Hidden=��� -7   $ txt_bl_home��$
��Wrap=�$��19.5,101.5,20.5,0q�$��32(�$��Monotype Corsiva)�$
��Bold"�$��Center=����� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFA61499��$	 0.908Q�� $ 	#FF080707��$	 0.189Q��� $"�GAS LAW COMPUTATION SOFTWARE���� �� $� ���� �� $�	DESIGNED BY ���� �� $�	JAMILU SHITU���� �� $� 	COMP14/14754���� �� �� �� $�		SUPERVISED BY���� �� $� 		Mr. BELLO MUAZU���� �� �� �� �� �� -8   $ txt_bl_footer��$��-7.607,0,20.838,12.098q�$
��Wrap=�$��Bottom=�$��3��$��5��$��26.667(����	#FF2D12D8   /   
BlurRadius$/ 3Q�$	 0.5Q�$ 3Q��� $�Designed By���� �� $"� Jamilu Shitu : COMP14/14754��