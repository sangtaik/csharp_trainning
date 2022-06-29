using System;
using System.Diagnostics;
 
namespace RunPython
{
    class Program
    {
        static void Main(string[] args)
        {
            //프로세스 파일명 정의
            //파이썬 exe를 직접 실행해서 파이썬 코드가 실행되도록 한다.
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\sangt\anaconda3\envs\STT\python.exe"; //파이썬 설치 경로
            //psi.Arguments = $"\"C:\\Users\\sangt\\AI_Training\\STT\\client\\main_run.py\""; // 이 파일은 pyqt로 만든 py로 실행 응답이 안옴.
            psi.Arguments = $"\"test.py\""; //파일경로
            //3) Proecss configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
 

            Console.WriteLine(psi.FileName);
            Console.WriteLine(psi.Arguments);
            //4) return value def
            var erros = "";
            var results = "";
            try {
                using (var process = Process.Start(psi))
                {
                    if (process != null) {
                        erros = process.StandardError.ReadToEnd();
                        results = process.StandardOutput.ReadToEnd();
                    }

                }

            }
            catch(Exception ex) {
                Console.WriteLine(ex);
                Console.WriteLine(ex.StackTrace);
            }
            finally {
                Console.WriteLine(erros);
                Console.WriteLine(results);
            }


            

 

 
        }
    }
}
