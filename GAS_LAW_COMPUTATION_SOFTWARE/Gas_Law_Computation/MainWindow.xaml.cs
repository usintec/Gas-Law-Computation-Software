using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gas_Law_Computation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// declaration of objects occures here.note that all delclared objects are private objects of MainWindow object
        /// </summary>
        private menu_items menu_items_selected;//an enum object which is a memeber of MainWindow is declared and used later on to store the selected menu item
        private computation_items computation_items_selected;//another enum object which is a member of MainWindow is declared and used later on to store the selected sub menu item
        private Event_Object application_event;//an object with "application_event" as the name is declared and used later on to manage our program logic event
        //Gas_Law law;

        private TextEffect[] formular_effect_numerator;//a TextEffect object is declared with "formular_effect_numerator" as the name and used later on to store effects applied to the formular textblock
        private TextEffect[] formular_effect_denominator;//a TextEffect object is declared with "formular_effect_denominator" as the name and used later on to store effects applied to the formular textblock
        private bool formular_effect_applied = true;//this variable is initialized to true meaning that effect is applied by default to the formular TextBlocks

        private double computed_value;
        private Dictionary<string, string> final_result;

        private Canvas new_chart_canvas;
        private Canvas new_text_canvas;
        //private Canvas new_text_canvas;
        public MainWindow()
        {
            //note that all this happens at the contruction time of MainWidow Object which happens to be parent object of the application
            InitializeComponent();
            
            new_text_canvas = new Canvas();
            try
            {
                this.set_menu_items = menu_items.Home;//the menu item is set to home at the start of the application
                this.set_user_interface();//this function adjust the user interface accordingly in response to the selected menu item
                this.final_result = new Dictionary<string, string>();

                application_event = new Event_Object();
                application_event.initialize_interface_event += this.set_user_interface;

                formular_effect_numerator = new TextEffect[txt_bl_formular_numerator.TextEffects.Count()];
                txt_bl_formular_numerator.TextEffects.CopyTo(formular_effect_numerator, 0);

                formular_effect_denominator = new TextEffect[txt_bl_formular_denominator.TextEffects.Count()];
                txt_bl_formular_denominator.TextEffects.CopyTo(formular_effect_denominator, 0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// menu_items is an enum object holding all the possible menu items that can be selected and also giving us the chance to set the object to hold one item at a time
        /// </summary>
        private enum menu_items
        {
            Home = 1,
            Boyles_Law = 2,
            Charles_Law = 3,
            Gas_Equarion = 4,
            Help = 5
        }
        private enum computation_items
        {
            Boyles_P1 = 1,
            Boyles_P2 = 2,
            Boyles_V1 = 3,
            Boyles_V2 = 4,

            Charles_V1 = 5,
            Charles_V2 = 6,
            Charles_T1 = 7,
            Charles_T2 = 8,

            Ideal_Gas_Equation_P = 9,
            Ideal_Gas_Equation_V = 10,
            Ideal_Gas_Equation_N = 11,
            Ideal_Gas_Equation_T = 12,

            Boyles_Authomation = 13,
            Charles_Authomation = 14,

            None = 15
        }
        /// <summary>
        /// this function set the text or content property of the lable controls in grid_data_input of the main window
        /// </summary>
        /// <param name="first_label"></param>
        /// <param name="second_label"></param>
        /// <param name="third_label"></param>
        private void set_label_information(string first_label, string second_label, string third_label)
        {
            try
            {
                lbl_first_parameter.Content = first_label;
                lbl_second_parameter.Content = second_label;
                lbl_third_parameter.Content = third_label;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void set_combo_box_information(string first_parameter_unit_of_measurement,
            string second_parameter_unit_of_measurement, string third_parameter_unit_of_measurement, 
            bool clear_combo_box = false)
        {
            try
            {
                if (clear_combo_box)
                {
                    cmb_first_parameter.Items.Clear();
                    cmb_second_parameter.Items.Clear();
                    cmb_third_parameter.Items.Clear();

                    cmb_first_parameter.SelectedValue = first_parameter_unit_of_measurement;
                    cmb_second_parameter.SelectedValue = second_parameter_unit_of_measurement;
                    cmb_third_parameter.SelectedValue = third_parameter_unit_of_measurement;
                }
                cmb_first_parameter.Items.Add(first_parameter_unit_of_measurement);
                cmb_second_parameter.Items.Add(second_parameter_unit_of_measurement);
                cmb_third_parameter.Items.Add(third_parameter_unit_of_measurement);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Dictionary<string, string> get_final_result
        {
            get { return this.final_result; }
        }
        private void set_final_result(string value_information, string value)
        {
            this.final_result.Add(value_information, value);
        }
        private void clear_final_result()
        {
            this.final_result.Clear();
        }
        private void updadate_final_result_dictionary(double numerator1, double numerator2, double denominator)
        {
            try
            {
                this.clear_final_result();//clear the final result dictionary
                switch (this.computation_items_selected)
                {
                    //boyles law computation starts here
                    case (computation_items.Boyles_P1):
                        this.set_final_result("Pressure At State 2", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Volume At State 2", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Volume At State 1", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Pressure At State 1", this.computed_value.ToString() + " " + cmb_first_parameter.Text);//computed value is added to the dict
                        break;
                    case (computation_items.Boyles_P2):
                        this.set_final_result("Pressure At State 1", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Volume At State 1", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Volume At State 2", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Pressure At State 2", this.computed_value.ToString() + " " + cmb_first_parameter.Text);//computed value is added to the dict
                        break;
                    case (computation_items.Boyles_V1):
                        this.set_final_result("Pressure At State 2", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Volume At State 2", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Pressure At State 1", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Volume At State 1", this.computed_value.ToString() + " " + cmb_second_parameter.Text);//computed value is added to the dict
                        break;
                    case (computation_items.Boyles_V2):
                        this.set_final_result("Pressure At State 1", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Volume At State 1", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Pressure At State 2", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Volume At State 2", this.computed_value.ToString() + " " + cmb_first_parameter.Text);//computed value is added to the dict
                        break;
                    case (computation_items.Boyles_Authomation):

                        break;
                    //charles law computation starts here
                    case (computation_items.Charles_T1):
                        this.set_final_result("Volume At State 1", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Temperature At State 2", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Volume At State 2", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Temperature At State 1", this.computed_value.ToString() + " " + cmb_first_parameter.Text);//computed value is added to the dict
                        break;
                    case (computation_items.Charles_T2):
                        this.set_final_result("Volume At State 2", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Temperature At State 1", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Volume At State 1", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Temperature At State 2", this.computed_value.ToString() + " " + cmb_first_parameter.Text);//computed value is added to the dict
                        break;
                    case (computation_items.Charles_V1):
                        this.set_final_result("Volume At State 2", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Temperature At State 1", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Temperature At State 2", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Volume At State 1", this.computed_value.ToString() + " " + cmb_first_parameter.Text);//computed value is added to the dict
                        break;
                    case (computation_items.Charles_V2):
                        this.set_final_result("Volume At State 1", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Temperature At State 2", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Temperature At State 1", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Volume At State 2", this.computed_value.ToString() + " " + cmb_first_parameter.Text);//computed value is added to the dict
                        break;
                    case (computation_items.Charles_Authomation):

                        break;
                    //Ideal Gas Equation starts here
                    case (computation_items.Ideal_Gas_Equation_N):
                        this.set_final_result("Mole", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Temperature", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Pressure", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Volume", this.computed_value.ToString() + " " + cmb_first_parameter.Text);//computed value is added to the dict
                        break;
                    case (computation_items.Ideal_Gas_Equation_P):
                        this.set_final_result("Mole", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Temperature", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Volume", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Pressure", this.computed_value.ToString() + " " + cmb_first_parameter.Text);//computed value is added to the dict
                        break;
                    case (computation_items.Ideal_Gas_Equation_T):
                        this.set_final_result("Pressure", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Volume", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Mole", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Temperature", this.computed_value.ToString() + " " + cmb_first_parameter.Text);//computed value is added to the dict
                        break;
                    case (computation_items.Ideal_Gas_Equation_V):
                        this.set_final_result("Mole", numerator1.ToString() + " " + cmb_first_parameter.Text);
                        this.set_final_result("Temperature", numerator2.ToString() + " " + cmb_second_parameter.Text);
                        this.set_final_result("Pressure", denominator.ToString() + " " + cmb_third_parameter.Text);
                        this.set_final_result("Volume", this.computed_value.ToString() + " " + cmb_first_parameter.Text);//computed value is added to the dict
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double conversion(string value_measurement_unit, Conversion convert_operation, double value, bool default_test = true)
        {
            double converted_value = 0.0;
            switch(value_measurement_unit)
            {
                case ("Liter"):
                    converted_value = convert_operation.volume_conversion_from_liter_to_cm_cube(value);
                    break;
                case ("Kelvin"):
                    converted_value = convert_operation.temperature_conversion_from_kelvin_to_celsius(value);
                    break;
                case ("CM Cube"):
                    converted_value = convert_operation.volume_conversion_from_cm_cube_to_liter(value);
                    break;
                case ("Celsius"):
                    converted_value = convert_operation.temperature_conversion_from_celsius_to_kelvin(value);
                    break;
                case ("atm"):
                    converted_value = convert_operation.pressure_conversion_from_atm_to_torrs(value);
                    break;
                case ("torrs"):
                    converted_value = convert_operation.pressure_conversion_from_torrs_to_atm(value);
                    break;
                case ("mole"):
                    converted_value = value;
                    break;
            }
            return converted_value;
        }
        public Action empty_delegate = delegate () { };
        private void computation(object numerator1, object numerator2, object denominator)
        {
            try
            {
                Boyles_Law Boyles_Law_computation = new Boyles_Law();//instance of Boyles_Law object is delclared with Boyles_Law_computation as the name of the object

                double numerator1_to_double = 0.0;
                double numerator2_to_double = 0.0;
                double denominator_to_double = 0.0;
                try
                {
                    numerator1_to_double = double.Parse(numerator1.ToString());
                    numerator2_to_double = double.Parse(numerator2.ToString());
                    denominator_to_double = double.Parse(denominator.ToString());

                    //if the user selects boyles law menu item or charles law menu item
                    if (set_menu_items_selected == menu_items.Boyles_Law ||
                        this.set_menu_items_selected == menu_items.Charles_Law)
                    {

                        //if the user does not select automation sub menu item of boyles law menu item
                        if (this.set_computation_items_selected != computation_items.Boyles_Authomation &&
                            this.set_computation_items_selected != computation_items.Charles_Authomation)
                        {
                            Boyles_Law Boyles_Law_compute = new Boyles_Law();//instance of Boyles_Law object is delclared with Boyles_Law_computation as the name of the object

                            //this function is used to compute p1,p2,v1,v2,t1,t2 and the result is stored in "computed_value
                            this.computed_value = Math.Round(Boyles_Law_computation.Compute_Boyles_Charles_Law(numerator1_to_double,
                                numerator2_to_double, denominator_to_double), 1, MidpointRounding.AwayFromZero);
                            this.updadate_final_result_dictionary(numerator1_to_double, numerator2_to_double,
                                denominator_to_double);
                            string chart_title = "";
                            string chart_x_axis = "";

                            double[] pressure = new double[2];
                            if (this.menu_items_selected == menu_items.Boyles_Law)
                            {
                                chart_title = "BOYLES LAW GRAPH";
                                chart_x_axis = "Pressure";
                                pressure[0] = Math.Round(Convert.ToDouble(get_final_result["Pressure At State 1"].Split(' ')[0]),
                                   1, MidpointRounding.AwayFromZero);
                                pressure[1] = Math.Round(Convert.ToDouble(get_final_result["Pressure At State 2"].Split(' ')[0]),
                                   1, MidpointRounding.AwayFromZero);
                            }
                            else if (this.menu_items_selected == menu_items.Charles_Law)
                            {
                                chart_title = "CHARLES LAW GRAPH";
                                chart_x_axis = "Temperature";
                                pressure[0] = Math.Round(Convert.ToDouble(get_final_result["Temperature At State 1"].Split(' ')[0]),
                                   1, MidpointRounding.AwayFromZero);
                                pressure[1] = Math.Round(Convert.ToDouble(get_final_result["Temperature At State 2"].Split(' ')[0]),
                                   1, MidpointRounding.AwayFromZero);
                            }
                            double[] volume = { Math.Round(Convert.ToDouble(get_final_result["Volume At State 1"].Split(' ')[0]),
                            1, MidpointRounding.AwayFromZero), Math.Round(Convert.ToDouble(get_final_result["Volume At State 2"].Split(' ')[0]),
                            1, MidpointRounding.AwayFromZero)};
                            double[] settings = { pressure.Min(), pressure.Max(), volume.Min(), volume.Max() };

                            //new_text_canvas = new Canvas();
                            new_text_canvas.Children.Clear();
                            new_text_canvas.Width = 270;
                            new_text_canvas.Height = 250;

                            chart_border.Child = new_text_canvas;

                            new_chart_canvas = new Canvas();
                            new_chart_canvas.Height = 225.761;
                            new_chart_canvas.Width = 270;

                            new_text_canvas.Children.Add(new_chart_canvas);

                            Boyles_Law_compute.AddChart(new_chart_canvas, new_text_canvas, txt_block_title,
                                txt_block_x_axis, txt_block_y_axis, chart_title, "Volume", chart_x_axis,
                                settings, false, null, pressure, volume);

                            this.display_result_datagrid();
                        }
                    }
                    //if the user selects gas equation
                    else if (this.set_menu_items_selected == menu_items.Gas_Equarion)
                    {
                        //if the user is computing for pressure of volume
                        if (this.set_computation_items_selected == computation_items.Ideal_Gas_Equation_P ||
                            this.set_computation_items_selected == computation_items.Ideal_Gas_Equation_V)
                        {
                            this.computed_value = Boyles_Law_computation.Compute_Gas_Equation_Pressure_Volume(numerator1_to_double,
                                numerator2_to_double, denominator_to_double);
                            this.updadate_final_result_dictionary(numerator1_to_double, numerator2_to_double,
                                denominator_to_double);
                            this.display_result_datagrid();
                        }
                        //if the user is computing for mole or temperature
                        else if (this.set_computation_items_selected == computation_items.Ideal_Gas_Equation_N ||
                            this.set_computation_items_selected == computation_items.Ideal_Gas_Equation_T)
                        {
                            this.computed_value = Boyles_Law_computation.Compute_Gas_Equation_Mole_Temperature(numerator1_to_double,
                                numerator2_to_double, denominator_to_double);
                            this.updadate_final_result_dictionary(numerator1_to_double, numerator2_to_double,
                                denominator_to_double);
                            this.display_result_datagrid();
                        }
                    }
                }
                catch(FormatException ex)
                {
                    if (this.set_computation_items_selected == computation_items.Boyles_Authomation ||
                         this.set_computation_items_selected == computation_items.Charles_Authomation)
                    { }else
                        MessageBox.Show(ex.Message);
                }
                
                //if the user selects automation sub menu item of boyles law menu item 
                if (this.set_menu_items_selected == menu_items.Boyles_Law &&
                    this.set_computation_items_selected == computation_items.Boyles_Authomation)
                {
                    this.authomation_computation(numerator1, numerator2, denominator);
                }
                //if the user selects automation sub menu item of boyles law menu item
                else if (this.set_menu_items_selected == menu_items.Charles_Law &&
                    this.set_computation_items_selected == computation_items.Charles_Authomation)
                {
                    this.authomation_computation(numerator1, numerator2, denominator, false);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void authomation_computation(object numerator1, object numerator2, object denominator,
             bool boyles_law = true)
        {
            Dictionary<string, string> final_result = new Dictionary<string, string>();
            try
            {
                bool is_decimal = false;
                string[] first_parameter_clean_up = numerator1.ToString().Split('-'); //this is for error checking 
                if (string.IsNullOrEmpty(numerator1.ToString()))//if the first parameter is empty
                {
                    if (!string.IsNullOrEmpty(numerator2.ToString()))//if the second parameter is not empty
                        first_parameter_clean_up = numerator2.ToString().Split('-');//minimum to maximum value
                }
                else if (!string.IsNullOrEmpty(numerator1.ToString()))//if the first parameter is not empty
                {
                    if (string.IsNullOrEmpty(numerator2.ToString()))//if the second parameter is emtpy
                        first_parameter_clean_up = numerator1.ToString().Split('-');//minimum to maximum value
                }
                string[] second_parameter_clean_up = denominator.ToString().Split('-');//known item and known value

                if (!string.IsNullOrEmpty(first_parameter_clean_up[0]) && !string.IsNullOrEmpty(first_parameter_clean_up[1]) &&
                    !string.IsNullOrEmpty(second_parameter_clean_up[0]) && !string.IsNullOrEmpty(second_parameter_clean_up[1]))
                {

                    if (first_parameter_clean_up[0].Contains("."))
                        is_decimal = true;

                    if (Convert.ToDouble(first_parameter_clean_up[0]) < Convert.ToDouble(first_parameter_clean_up[1]))
                    {
                        List<double> list_of_unknown_item = new List<double>();
                        if (!is_decimal)
                        {
                            for (double value = Convert.ToDouble(first_parameter_clean_up[0]);
                                value <= Convert.ToDouble(first_parameter_clean_up[1]); value += 1)
                            {
                                //add each and every valued starting from the minimum value down to the maximum value
                                list_of_unknown_item.Add(value);
                            }
                        }
                        else if (is_decimal)
                        {
                            for (double value = Convert.ToDouble(first_parameter_clean_up[0]);
                                 value <= Convert.ToDouble(first_parameter_clean_up[1]); value += 0.1)
                            {
                                value = Math.Round(value, 1, MidpointRounding.AwayFromZero);
                                //add each and every valued starting from the minimum value down to the maximum value
                                list_of_unknown_item.Add(value);
                            }
                        }
                        //if the supplied unknown item (the value afte dash is the value od the unknow item making it known item) is 
                        //found in the list of unknow item
                        if (list_of_unknown_item.Contains(Convert.ToDouble(second_parameter_clean_up[0])))
                        {
                            Dictionary<double, double> Authomation_result = new Dictionary<double, double>();
                            if (boyles_law)
                            {
                                Boyles_Law gas_computation = new Boyles_Law();
                                //boyles law automation function is called here with retunr value (dictionary) saved in Authomation_result
                                Authomation_result = gas_computation.Compute_Automation(
                                    Convert.ToDouble(second_parameter_clean_up[0]),
                                    Convert.ToDouble(second_parameter_clean_up[1]), list_of_unknown_item);
                            }
                            else if (!boyles_law)//charles law
                            {
                                Charles_Law gas_computation = new Charles_Law();
                                if (string.IsNullOrEmpty(numerator2.ToString()) && !string.IsNullOrEmpty(numerator1.ToString()))
                                {
                                    Authomation_result = gas_computation.Compute_Automation(
                                        Convert.ToDouble(second_parameter_clean_up[0]),
                                        Convert.ToDouble(second_parameter_clean_up[1]), list_of_unknown_item, false);
                                }
                                else if (!string.IsNullOrEmpty(numerator2.ToString()) && string.IsNullOrEmpty(numerator1.ToString()))
                                {
                                    Authomation_result = gas_computation.Compute_Automation(
                                        Convert.ToDouble(second_parameter_clean_up[0]),
                                        Convert.ToDouble(second_parameter_clean_up[1]), list_of_unknown_item, true);
                                }
                            }
                            string chart_title = "";
                            string chart_x_axis = "";
                            // the global dictionary to hold the result of local dictionary (Authomation_result) is cleared
                            //this.clear_final_result();

                            if (boyles_law)
                            {
                                chart_title = "BOYLES LAW AUTOMATION GRAPH";
                                chart_x_axis = "Pressure";
                                //if the supplied unknow values is "pressure" the first row of the global dictionary is set accordingly
                                //i.e to reflect "pressure" in the first colume of the row
                                //otherwise, it is set to reflect "volume" in the first column of the row
                                if (string.IsNullOrEmpty(numerator2.ToString()) && !string.IsNullOrEmpty(numerator1.ToString()))
                                    final_result.Add("PRESSURE" + "(" + cmb_first_parameter.Text + ")",
                                        "VOLUME" + "(" + cmb_second_parameter.Text + ")");
                                else if (!string.IsNullOrEmpty(numerator2.ToString()) && string.IsNullOrEmpty(numerator1.ToString()))
                                    final_result.Add("VOLUME" + "(" + cmb_second_parameter.Text + ")",
                                        "PRESSURE" + "(" + cmb_first_parameter.Text + ")");
                            }
                            else if (!boyles_law)//then its charles law
                            {
                                chart_title = "CHARLES LAW AUTOMATION GRAPH";
                                chart_x_axis = "Temperature";
                                if (string.IsNullOrEmpty(numerator2.ToString()) && !string.IsNullOrEmpty(numerator1.ToString()))
                                    final_result.Add("TEMPERATURE" + "(" + cmb_first_parameter.Text + ")",
                                        "VOLUME" + "(" + cmb_second_parameter.Text + ")");
                                else if (!string.IsNullOrEmpty(numerator2.ToString()) && string.IsNullOrEmpty(numerator1.ToString()))
                                    final_result.Add("VOLUME" + "(" + cmb_second_parameter.Text + ")",
                                        "TEMPERATURE" + "(" + cmb_first_parameter.Text + ")");
                            }
                            foreach (double item in Authomation_result.Keys)
                            {
                                //MessageBox.Show(item.ToString() + " " + Authomation_result[item].ToString());
                                final_result.Add(item.ToString(), Authomation_result[item].ToString());
                            }
                            double[] settings = { Authomation_result.Keys.Min(), Authomation_result.Keys.Max(),
                                                    Authomation_result.Values.Min(), Authomation_result.Values.Max() };

                            //new_text_canvas = new Canvas();
                            new_text_canvas.Children.Clear();
                            new_text_canvas.Width = 270;
                            new_text_canvas.Height = 250;

                            chart_border.Child = new_text_canvas;

                            new_chart_canvas = new Canvas();
                            new_chart_canvas.Height = 225.761;
                            new_chart_canvas.Width = 270;

                            new_text_canvas.Children.Add(new_chart_canvas);

                            if (boyles_law)
                            {
                                Boyles_Law gas_computation = new Boyles_Law();
                                //this function generate graph for the result of the authomation computation
                                gas_computation.AddChart(new_chart_canvas, new_text_canvas, txt_block_title,
                                    txt_block_x_axis, txt_block_y_axis, chart_title, "Volume", chart_x_axis,
                                    settings, true, Authomation_result);
                                //this.display_result_datagrid();
                                dtg_computed.HeadersVisibility = DataGridHeadersVisibility.Row;
                                dtg_computed.ItemsSource = final_result;
                            }
                            else if (!boyles_law)
                            {
                                Charles_Law gas_computation = new Charles_Law();
                                //this function generate graph for the result of the authomation computation
                                gas_computation.AddChart(new_chart_canvas, new_text_canvas, txt_block_title,
                                    txt_block_x_axis, txt_block_y_axis, chart_title, "Volume", chart_x_axis,
                                    settings, true, Authomation_result);
                                //this.display_result_datagrid();
                                dtg_computed.HeadersVisibility = DataGridHeadersVisibility.Row;
                                dtg_computed.ItemsSource = final_result;
                            }

                        }
                        else
                            MessageBox.Show("The know item provided is not found in range supplied", "Inappropriate Value",
                                 MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("First Value Should Be Less Than Second Value", "Inappropriate Value",
                             MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid Input", "Consult User's Manual or Help", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void clear_chart_info()
        {
            this.txt_block_title.Text = "";
            this.txt_block_x_axis.Text = "";
            this.txt_block_y_axis.Text = "";
        }
        private void display_result_datagrid()
        {
            try
            {
                dtg_computed.HeadersVisibility = DataGridHeadersVisibility.Row;
                dtg_computed.ItemsSource = final_result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private computation_items set_computation_items_selected
        {
            set { this.computation_items_selected = value; }
            get { return this.computation_items_selected; }
        }
        private menu_items set_menu_items_selected
        {
            set { this.menu_items_selected = value; }
            get { return this.menu_items_selected; }
        }
        private void set_textblock_formular_information(string numerator, string denominator = "", bool automation = false)
        {
            try
            {
                if (automation)
                {
                    txt_bl_formular_denominator.TextEffects.Clear();
                    txt_bl_formular_numerator.TextEffects.Clear();
                    this.formular_effect_applied = false;
                    this.toggle_formular_window_controls(Visibility.Visible, true);

                }
                else if (!automation)
                {
                    if (!this.formular_effect_applied)
                    {
                        foreach (TextEffect value in formular_effect_numerator)
                        {
                            txt_bl_formular_numerator.TextEffects.Add(value);
                        }
                        foreach (TextEffect value in formular_effect_denominator)
                        {
                            txt_bl_formular_denominator.TextEffects.Add(value);
                        }
                        this.formular_effect_applied = true;
                    }
                    this.toggle_formular_window_controls(Visibility.Visible);
                }
                txt_bl_formular_denominator.Text = denominator;
                txt_bl_formular_numerator.Text = numerator;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// this function set and return "menu_items_selected" which happens to be variable holding our selected menu item
        /// </summary>
        private menu_items set_menu_items
        {
            set { this.menu_items_selected = value; }
            get { return this.menu_items_selected; }
        }
        /// <summary>
        /// //this function adjust the user interface accordingly in response to the selected menu item
        /// </summary>
        private void set_user_interface()
        {
            try
            {
                switch (this.menu_items_selected)
                {
                    case menu_items.Home:
                        new_text_canvas.Children.Clear();
                        this.toggle_help_content(Visibility.Hidden);
                        this.toggle_formular_window_controls(Visibility.Hidden);
                        this.toggle_computation_window_controls(Visibility.Hidden);
                        this.toggle_home_content(Visibility.Visible);
                        break;
                    case menu_items.Boyles_Law:
                        new_text_canvas.Children.Clear();
                        this.toggle_help_content(Visibility.Hidden);
                        this.toggle_home_content(Visibility.Hidden);
                        clear_chart_info();
                        this.toggle_computation_window_controls(Visibility.Visible);
                        switch (this.computation_items_selected)
                        {
                            case (computation_items.Boyles_P1):
                                this.set_textblock_formular_information("P1 = P2V2", "V1");
                                this.set_label_information("Pressure At State 2", "Volume At State 2", "Volume At State 1");
                                this.set_combo_box_information("atm", "Liter", "Liter", true);
                                this.set_combo_box_information("torrs", "CM Cube", "CM Cube");
                                break;
                            case (computation_items.Boyles_P2):
                                this.set_textblock_formular_information("P2 = P1V1", "V2");
                                this.set_label_information("Pressure At State 1", "Volume At State 1", "Pressure At State 2");
                                this.set_combo_box_information("atm", "Liter", "atm", true);
                                this.set_combo_box_information("torrs", "CM Cube", "torrs");
                                break;
                            case (computation_items.Boyles_V1):
                                this.set_textblock_formular_information("V1 = P2V2", "P1");
                                this.set_label_information("Pressure At State 2", "Volume At State 2", "Pressure At State 1");
                                this.set_combo_box_information("atm", "Liter", "atm", true);
                                this.set_combo_box_information("torrs", "CM Cube", "torrs");
                                break;
                            case (computation_items.Boyles_V2):
                                this.set_textblock_formular_information("V2 = P1V1", "V2");
                                this.set_label_information("Pressure At State 1", "Volume At State 1", "Pressure At State 2");
                                this.set_combo_box_information("atm", "Liter", "atm", true);
                                this.set_combo_box_information("torrs", "CM Cube", "torrs");
                                break;
                            case (computation_items.Boyles_Authomation):
                                //this.set_textblock_formular_information("PV = nRT", "", true);
                                this.set_textblock_formular_information("C = PV", "", true);
                                this.set_label_information("Range Of Pressure", "Range Of Volume", "Pressure/Volume");
                                this.set_combo_box_information("atm", "Liter", "atm", true);
                                this.set_combo_box_information("torrs", "CM Cube", "torrs");
                                break;
                        }
                        break;
                    case menu_items.Charles_Law:
                        new_text_canvas.Children.Clear();
                        this.toggle_help_content(Visibility.Hidden);
                        this.toggle_home_content(Visibility.Hidden);
                        clear_chart_info();
                        this.toggle_computation_window_controls(Visibility.Visible);
                        switch (this.computation_items_selected)
                        {
                            case (computation_items.Charles_T1):
                                this.set_textblock_formular_information("T1 = V1T2", "V2");
                                this.set_label_information("Volume At State 1", "Temperature At State 2", "Volume At State 2");
                                this.set_combo_box_information("Liter", "Kelvin", "Liter", true);
                                this.set_combo_box_information("CM Cube", "Celsius", "CM Cube");
                                break;
                            case (computation_items.Charles_T2):
                                this.set_textblock_formular_information("T2 = V2T1", "V1");
                                this.set_label_information("Volume At State 2", "Temperature At State 1", "Volume At State 1");
                                this.set_combo_box_information("Liter", "Kelvin", "Liter", true);
                                this.set_combo_box_information("CM Cube", "Celsius", "CM Cube");
                                break;
                            case (computation_items.Charles_V1):
                                this.set_textblock_formular_information("V1 = V2T1", "T2");
                                this.set_label_information("Volume At State 2", "Temperature At State 1", "Temperature At State 2");
                                this.set_combo_box_information("Liter", "Kelvin", "Kelvin", true);
                                this.set_combo_box_information("CM Cube", "Celsius", "Celsius");
                                break;
                            case (computation_items.Charles_V2):
                                this.set_textblock_formular_information("V2 = V1T2", "T1");
                                this.set_label_information("Volume At State 1", "Temperature At State 2", "Temperature At State 1");
                                this.set_combo_box_information("Liter", "Kelvin", "Kelvin", true);
                                this.set_combo_box_information("CM Cube", "Celsius", "Celsius");
                                break;
                            case (computation_items.Charles_Authomation):
                                this.set_textblock_formular_information("C = V / T", "", true);
                                this.set_label_information("Range Of Temperature", "Range Of Volume", "Temperature/Volume");
                                this.set_combo_box_information("Kelvin", "Liter", "Kelvin", true);
                                this.set_combo_box_information("Celsius", "CM Cube", "Celsius");
                                break;
                        }
                        break;
                    case menu_items.Gas_Equarion:
                        new_text_canvas.Children.Clear();
                        this.toggle_help_content(Visibility.Hidden);
                        this.toggle_home_content(Visibility.Hidden);
                        clear_chart_info();
                        this.toggle_computation_window_controls(Visibility.Visible);
                        switch (this.computation_items_selected)
                        {
                            case (computation_items.Ideal_Gas_Equation_N):
                                this.set_textblock_formular_information("n = PV / RT", "", true);
                                this.set_label_information("Pressure (P)", "Volume (V)", "Temperature (T)");
                                this.set_combo_box_information("atm", "Liter", "Kelvin", true);
                                this.set_combo_box_information("torrs", "CM Cube", "Celsius");
                                break;
                            case (computation_items.Ideal_Gas_Equation_P):
                                this.set_textblock_formular_information("P = nRT / V", "", true);
                                this.set_label_information("Mole (n)", "Temperature (T)", "Volume (V)");
                                this.set_combo_box_information("mole", "Kelvin", "Liter", true);
                                this.set_combo_box_information("", "Celsius", "CM Cube");
                                break;
                            case (computation_items.Ideal_Gas_Equation_T):
                                this.set_textblock_formular_information("T = PV / nR", "", true);
                                this.set_label_information("Pressure (P)", "Volume (V)", "Mole (n)");
                                this.set_combo_box_information("atm", "Liter", "Kelvin", true);
                                this.set_combo_box_information("torrs", "CM Cube", "Celsius");
                                break;
                            case (computation_items.Ideal_Gas_Equation_V):
                                this.set_textblock_formular_information("V = nRT / P", "", true);
                                this.set_label_information("Mole (n)", "Temperature (T)", "Pressure (P)");
                                this.set_combo_box_information("mole", "Kelvin", "atm", true);
                                this.set_combo_box_information("", "Celsius", "torrs");
                                break;
                        }
                        break;
                    case menu_items.Help:
                        new_text_canvas.Children.Clear();
                        this.toggle_help_content(Visibility.Visible);
                        this.toggle_home_content(Visibility.Hidden);
                        this.toggle_formular_window_controls(Visibility.Hidden);
                        this.toggle_computation_window_controls(Visibility.Hidden);
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// this fucntion set the window controls used for computation to the the value passed in to the parameter
        /// which can either be hidden or visible
        /// </summary>
        /// <param name="toggle_visibility"></param>
        private void toggle_computation_window_controls(Visibility toggle_visibility)
        {
            try
            {
                grid_computed_result.Visibility = toggle_visibility;
                viewbox_graph.Visibility = toggle_visibility;
                grid_input_data.Visibility = toggle_visibility;
                txt_block_title.Visibility = toggle_visibility;
                txt_block_x_axis.Visibility = toggle_visibility;
                txt_block_y_axis.Visibility = toggle_visibility;
                prb_status.Visibility = toggle_visibility;
                grid_graph.Visibility = toggle_visibility;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void toggle_help_content(Visibility toggle_visibility)
        {
            this.txt_bl_help.Visibility = toggle_visibility;
        }
        private void toggle_home_content(Visibility toggle_visibility)
        {
            this.txt_bl_home.Visibility = toggle_visibility;
        }
        private void toggle_formular_window_controls(Visibility toggle_visibility, bool automation = false)
        {
            try
            {
                txt_bl_formular_numerator.Visibility = toggle_visibility;
                txt_bl_formular_denominator.Visibility = toggle_visibility;
                if (!automation)
                    rect_division.Visibility = toggle_visibility;
                else if (automation)
                    rect_division.Visibility = Visibility.Hidden;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void set_state(menu_items selected_menu_item, computation_items selected_computation_item)
        {
            try
            {
                this.set_menu_items_selected = selected_menu_item;//save the selected menu item
                this.set_computation_items_selected = selected_computation_item;//save the selected sub menu item

                application_event.initialize_user_interface();//fire the event
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void sbm_boyles_p1_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Boyles_Law, computation_items.Boyles_P1);
        }

        private void sbm_boyles_volume_v1_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Boyles_Law, computation_items.Boyles_V1);
        }

        private void sbm_boyles_p2_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Boyles_Law, computation_items.Boyles_P2);
        }

        private void sbm_boyles_volumes_v2_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Boyles_Law, computation_items.Boyles_V2);
        }

        private void smb_boyles_automation_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Boyles_Law, computation_items.Boyles_Authomation);
        }

        private void sbm_charles_t1_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Charles_Law, computation_items.Charles_T1);
        }

        private void sbm_charles_v1_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Charles_Law, computation_items.Charles_V1);
        }

        private void sbm_charles_t2_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Charles_Law, computation_items.Charles_T2);
        }

        private void sbm_charles_v2_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Charles_Law, computation_items.Charles_V2);
        }

        private void sbm_charles_automation_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Charles_Law, computation_items.Charles_Authomation);
        }

        private void sbm_gas_mole_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Gas_Equarion, computation_items.Ideal_Gas_Equation_N);
        }

        private void sbm_gas_temperature_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Gas_Equarion, computation_items.Ideal_Gas_Equation_T);
        }

        private void sbm_gas_volume_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Gas_Equarion, computation_items.Ideal_Gas_Equation_V);
        }

        private void sbm_gas_pressure_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Gas_Equarion, computation_items.Ideal_Gas_Equation_P);
        }

        private void mnu_home_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Home, computation_items.None);
        }

        private void mnu_help_Click(object sender, RoutedEventArgs e)
        {
            this.set_state(menu_items.Help, computation_items.None);
        }

        private void btn_compute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dtg_computed.Items.Refresh();//refresh the dataview
               
                this.computation(txt_first_parameter.Text, txt_second_parameter.Text,
                    txt_third_parameter.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_first_parameter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(this.set_computation_items_selected == computation_items.Boyles_Authomation || 
                this.set_computation_items_selected == computation_items.Charles_Authomation)
            {
                if (txt_first_parameter.Text != "")
                    txt_second_parameter.IsEnabled = false;
                else
                    txt_second_parameter.IsEnabled = true;
            }
        }

        private void txt_second_parameter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.set_computation_items_selected == computation_items.Boyles_Authomation ||
                this.set_computation_items_selected == computation_items.Charles_Authomation)
            {
                if (txt_second_parameter.Text != "")
                    txt_first_parameter.IsEnabled = false;
                else
                    txt_first_parameter.IsEnabled = true;
            }
        }

        private void btn_clear_all_Click(object sender, RoutedEventArgs e)
        {
            this.txt_first_parameter.Text = "";
            this.txt_second_parameter.Text = "";
            this.txt_third_parameter.Text = "";
        }
    }
}
