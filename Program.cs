/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 4/30/2018
 * Time: 9:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;

namespace NewStudentMarkList
{
	class Program
	{
		static string[] courses;
		static int no_of_courses;
		static int no_of_students;
		static int []student_scores;
		static string []student_names;
		static int [] positions;
		static string [,] overall_table;
		
		public static void Main(string[] args)
		{
			show();
			readStudents();
			computeAverage();
			computePosition();
			display(); 
			Console.ReadLine();
		}
		
		static void show(){
			Console.Write("How many Courses would you like to Compute for?   ");
			no_of_courses = Int32.Parse(Console.ReadLine());
			courses = new string[no_of_courses];
			
			//Console.WriteLine("Enter the courses below, each on a new line");
			for (int i = 0; i < no_of_courses; i++){
				Console.Write("Enter the course name for course {0}   ", i+1);
				courses[i] = Console.ReadLine();
			}
			Console.WriteLine();
		}
		
		static void readStudents(){
			Console.Write("How many students are you computing for?   ");
			no_of_students = Int32.Parse(Console.ReadLine());
			student_scores = new int[no_of_students];
			student_names = new string [no_of_students];
			positions = new int[no_of_students];
			overall_table = new String[no_of_students,no_of_courses+4];
			
			for(int j = 0; j < no_of_students; j++){
				Console.Write("Enter the name of student {0}   ", j+1);
				string name = Console.ReadLine();
				student_names[j] = name;
				overall_table[j,0] = name;
				
				int cummulative_sum = 0;
					Console.WriteLine("Details for {0}", name);
				for(int k = 0; k < no_of_courses; k++){
					Console.Write("Enter {0} score for {1} ", name, courses[k]);
					int score = Int32.Parse(Console.ReadLine());
					cummulative_sum += score;
					overall_table[j, k+1] = ""+score;
				}
					
					student_scores[j] = cummulative_sum;
					overall_table[j,no_of_courses+3] = ""+cummulative_sum;
					positions[j] = cummulative_sum;
					Console.WriteLine();
			}
			Console.WriteLine();
		}
		
		static void computeAverage(){
			/*int sum = 0
			for(int i = 0; i < no_of_students; i++){
				sum += student_scores[i];
			} */
			
			int sum = student_scores.Sum();
			int average = (int) (sum / no_of_students);
			
			for(int j = 0; j < no_of_students; j++){
				overall_table[j,no_of_courses+1] = ""+average;
			}
		}
		
		static void computePosition(){
			for(int i = 0; i < no_of_students; i++){
				 Array.Sort(positions);
				 Array.Reverse(positions);
				 int position = Array.IndexOf(positions, student_scores[i]) + 1;
				overall_table[i, no_of_courses+2] = ""+position;
			}
		}
		
		static void display(){
			Console.WriteLine("Student's score table");
			
			Console.Write("Student Names ");
			for (int k = 0; k < no_of_courses; k++){
				Console.Write(courses[k]+"  ");
			}
			Console.Write("Average Position Total");
			
			Console.WriteLine();
			for(int i = 0; i < no_of_students; i++){
				for(int j = 0; j < no_of_courses+4; j++){
					Console.Write(overall_table[i,j] +"\t");
				}
				Console.WriteLine();
			}
		}
		
		
	}
}