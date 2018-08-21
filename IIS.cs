using System;
using System.Collections.Generic;
using System.Linq;

namespace RX
{
    public static class IIS
    {

        //需要引用Microsoft.Web.Administration.dll
        //private static string Host = "localhost";

        ///// <summary>  
        /////     取得所有应用程序池  
        ///// </summary>  
        ///// <returns></returns>  
        //public static List<string> GetAppPools()
        //{
        //    var appPools = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
        //    return (from DirectoryEntry entry in appPools.Children select entry.Name).ToList();
        //}

        ///// <summary>  
        /////     取得单个应用程序池  
        ///// </summary>  
        ///// <returns></returns>  
        //public static ApplicationPool GetAppPool(string appPoolName)
        //{
        //    ApplicationPool app = null;
        //    var appPools = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
        //    foreach (DirectoryEntry entry in appPools.Children)
        //    {
        //        if (entry.Name == appPoolName)
        //        {
        //            var manager = new ServerManager();
        //            app = manager.ApplicationPools[appPoolName];
        //        }
        //    }
        //    return app;
        //}

        ///// <summary>  
        /////     判断程序池是否存在  
        ///// </summary>  
        ///// <param name="appPoolName">程序池名称</param>  
        ///// <returns>true存在 false不存在</returns>  
        //public static bool IsAppPoolExsit(string appPoolName)
        //{
        //    bool result = false;
        //    var appPools = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
        //    foreach (DirectoryEntry entry in appPools.Children)
        //    {
        //        if (entry.Name.Equals(appPoolName))
        //        {
        //            result = true;
        //            break;
        //        }
        //    }
        //    return result;
        //}

        ///// <summary>  
        /////     删除指定程序池  
        ///// </summary>  
        ///// <param name="appPoolName">程序池名称</param>  
        ///// <returns>true删除成功 false删除失败</returns>  
        //public static bool DeleteAppPool(string appPoolName)
        //{
        //    bool result = false;
        //    var appPools = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
        //    foreach (DirectoryEntry entry in appPools.Children)
        //    {
        //        if (entry.Name.Equals(appPoolName))
        //        {
        //            try
        //            {
        //                entry.DeleteTree();
        //                result = true;
        //                break;
        //            }
        //            catch
        //            {
        //                result = false;
        //            }
        //        }
        //    }
        //    return result;
        //}

        ///// <summary>  
        /////     创建应用程序池  
        ///// </summary>  
        ///// <param name="appPool"></param>  
        ///// <returns></returns>  
        //public static bool CreateAppPool(string appPool)
        //{
        //    try
        //    {
        //        if (!IsAppPoolExsit(appPool))
        //        {
        //            var appPools = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
        //            DirectoryEntry entry = appPools.Children.Add(appPool, "IIsApplicationPool");
        //            entry.CommitChanges();
        //            return true;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return false;
        //}

        ///// <summary>  
        /////     编辑应用程序池  
        ///// </summary>  
        ///// <param name="application"></param>  
        ///// <returns></returns>  
        //public static bool EditAppPool(ApplicationPool application)
        //{
        //    try
        //    {
        //        if (IsAppPoolExsit(application.Name))
        //        {
        //            var manager = new ServerManager();
        //            manager.ApplicationPools[application.Name].ManagedRuntimeVersion = application.ManagedRuntimeVersion;
        //            manager.ApplicationPools[application.Name].ManagedPipelineMode = application.ManagedPipelineMode;
        //            //托管模式Integrated为集成 Classic为经典  
        //            manager.CommitChanges();
        //            return true;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return false;
        //}
        //public static void getwebsitexml()
        //{

        //}
        ///// <summary>
        ///// 运行cmd命令
        ///// 会显示命令窗口
        ///// </summary>
        ///// <param name="cmdExe">指定应用程序的完整路径</param>
        ///// <param name="cmdStr">执行命令行参数</param>
        //static bool RunCmd(string cmdExe, string cmdStr)
        //{
        //    bool result = false;
        //    try
        //    {
        //        using (System.Diagnostics.Process myPro = new System.Diagnostics.Process())
        //        {
        //            //指定启动进程是调用的应用程序和命令行参数
        //            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(cmdExe, cmdStr);
        //            myPro.StartInfo = psi;
        //            myPro.Start();
        //            myPro.WaitForExit();
        //            result = true;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    return result;
        //}
        ///// <summary>
        ///// 运行cmd命令
        ///// 不显示命令窗口
        ///// </summary>

        ///// <param name="cmdStr">执行命令行参数</param>
        //public static bool RunCmd2(string cmdStr)
        //{
        //    bool result = false;
        //    try
        //    {
        //        using (System.Diagnostics.Process myPro = new System.Diagnostics.Process())
        //        {
        //            myPro.StartInfo.FileName = "cmd.exe";
        //            myPro.StartInfo.UseShellExecute = false;
        //            myPro.StartInfo.RedirectStandardInput = true;
        //            myPro.StartInfo.RedirectStandardOutput = true;
        //            myPro.StartInfo.RedirectStandardError = true;
        //            myPro.StartInfo.CreateNoWindow = true;
        //            myPro.Start();
        //            //如果调用程序路径中有空格时，cmd命令执行失败，可以用双引号括起来 ，在这里两个引号表示一个引号（转义）
        //            string str = string.Format(@"{0} {1}", cmdStr, "&exit");

        //            myPro.StandardInput.WriteLine(str);
        //            myPro.StandardInput.AutoFlush = true;
        //            myPro.WaitForExit();

        //            result = true;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    return result;
        //}
        ///// <summary>
        ///// 运行cmd命令
        ///// 不显示命令窗口
        ///// </summary>
        ///// <param name="cmdExe">指定应用程序的完整路径</param>
        ///// <param name="cmdStr">执行命令行参数</param>
        //public static bool RunCmd2(string cmdExe, string cmdStr)
        //{
        //    bool result = false;
        //    try
        //    {
        //        using (System.Diagnostics.Process myPro = new System.Diagnostics.Process())
        //        {
        //            myPro.StartInfo.FileName = "cmd.exe";
        //            myPro.StartInfo.UseShellExecute = false;
        //            myPro.StartInfo.RedirectStandardInput = true;
        //            myPro.StartInfo.RedirectStandardOutput = true;
        //            myPro.StartInfo.RedirectStandardError = true;
        //            myPro.StartInfo.CreateNoWindow = true;
        //            myPro.Start();
        //            //如果调用程序路径中有空格时，cmd命令执行失败，可以用双引号括起来 ，在这里两个引号表示一个引号（转义）
        //            string str = string.Format(@"""{0}"" {1} {2}", cmdExe, cmdStr, "&exit");

        //            myPro.StandardInput.WriteLine(str);
        //            myPro.StandardInput.AutoFlush = true;
        //            myPro.WaitForExit();

        //            result = true;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    return result;
        //}
        //public static List<string> EnumWebSite()
        //{
        //    DirectoryEntry de = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
        //    //DirectoryEntry de = new DirectoryEntry(strDePath);
        //    // PropertyValueCollection serverBindings = de.Properties["ServerBindings"];  

        //    List<string> list = new List<string>();
        //    foreach (DirectoryEntry child in de.Children)
        //    {
        //        PropertyValueCollection serverBindings = child.Properties["ServerBindings"];
        //        if (child.Site != null)
        //        {
        //            Console.WriteLine("Name: {0}", child.Name);
        //            Console.WriteLine("SchemaClassName: {0}", child.Site.Name);
        //            Console.WriteLine("ServerBindings: {0}", child.Properties["ServerBindings"].Value);
        //            Console.WriteLine();
        //            //DirectoryEntry virEntry = new DirectoryEntry(child.Path + "/ROOT");
        //        }
        //        if (child.SchemaClassName == "IIsWebServer")
        //        {
        //            list.Add(child.Properties["ServerComment"].Value.ToString());
        //        }

        //    }
        //    return list;
        //}
        ///// <summary>
        ///// 获取应用程序池->数组
        ///// </summary>
        ///// <returns></returns>
        //public static string[] GetApplicationPools()
        //{
        //    DirectoryEntry directoryEntry = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
        //    if (directoryEntry == null) return null;
        //    List<string> list = new List<string>();
        //    foreach (DirectoryEntry entry2 in directoryEntry.Children)
        //    {
        //        PropertyCollection properties = entry2.Properties;
        //        list.Add(entry2.Name.ToString().Trim());

        //    }
        //    return list.ToArray();
        //}
        ///// <summary>
        ///// 获取程序池状态
        ///// </summary>
        ///// <param name="poolName"></param>
        ///// <returns></returns>
        //public static ObjectState getAppPoolSatus(string poolName)
        //{
        //    ServerManager manager = new ServerManager();
        //    return manager.ApplicationPools[poolName].State;
        //}


        //#region 回收、停止、启动
        ///// <summary>
        ///// 回收、停止、启动
        ///// </summary>
        ///// <param name="appPoolName"></param>
        ///// <param name="method">（Recycle）、停止（Stop）、启动（Start）</param>
        ///// <returns></returns>
        //public static bool RSAppPool(string appPoolName, string method = "Recycle")
        //{
        //    //如果应用程序池当前状态为停止,则会发生异常报错
        //    try
        //    {
        //        DirectoryEntry appPool = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
        //        DirectoryEntry findPool = appPool.Children.Find(appPoolName, "IIsApplicationPool");
        //        findPool.Invoke(method, null);
        //        appPool.CommitChanges();
        //        appPool.Close();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //#endregion
    }
}
