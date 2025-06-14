﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserServiceClientReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDTO", Namespace="http://schemas.datacontract.org/2004/07/ServiceLibrary.DTOs")]
    public partial class UserDTO : object, System.ComponentModel.INotifyPropertyChanged
    {
        
        private string EmailField;
        
        private string FirstNameField;
        
        private int IdField;
        
        private bool IsAdminField;
        
        private string LastNameField;
        
        private string PasswordHashField;
        
        private string PasswordSaltField;
        
        private System.DateTime RegistrationDateField;
        
        private string UserNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                if ((object.ReferenceEquals(this.EmailField, value) != true))
                {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName
        {
            get
            {
                return this.FirstNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true))
                {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                if ((this.IdField.Equals(value) != true))
                {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsAdmin
        {
            get
            {
                return this.IsAdminField;
            }
            set
            {
                if ((this.IsAdminField.Equals(value) != true))
                {
                    this.IsAdminField = value;
                    this.RaisePropertyChanged("IsAdmin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName
        {
            get
            {
                return this.LastNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LastNameField, value) != true))
                {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PasswordHash
        {
            get
            {
                return this.PasswordHashField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PasswordHashField, value) != true))
                {
                    this.PasswordHashField = value;
                    this.RaisePropertyChanged("PasswordHash");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PasswordSalt
        {
            get
            {
                return this.PasswordSaltField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PasswordSaltField, value) != true))
                {
                    this.PasswordSaltField = value;
                    this.RaisePropertyChanged("PasswordSalt");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime RegistrationDate
        {
            get
            {
                return this.RegistrationDateField;
            }
            set
            {
                if ((this.RegistrationDateField.Equals(value) != true))
                {
                    this.RegistrationDateField = value;
                    this.RaisePropertyChanged("RegistrationDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName
        {
            get
            {
                return this.UserNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.UserNameField, value) != true))
                {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceClientReference.IUserService")]
    public interface IUserService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Login", ReplyAction="http://tempuri.org/IUserService/LoginResponse")]
        UserServiceClientReference.UserDTO Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Login", ReplyAction="http://tempuri.org/IUserService/LoginResponse")]
        System.Threading.Tasks.Task<UserServiceClientReference.UserDTO> LoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/RegisterUser", ReplyAction="http://tempuri.org/IUserService/RegisterUserResponse")]
        UserServiceClientReference.UserDTO RegisterUser(UserServiceClientReference.UserDTO user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/RegisterUser", ReplyAction="http://tempuri.org/IUserService/RegisterUserResponse")]
        System.Threading.Tasks.Task<UserServiceClientReference.UserDTO> RegisterUserAsync(UserServiceClientReference.UserDTO user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserById", ReplyAction="http://tempuri.org/IUserService/GetUserByIdResponse")]
        UserServiceClientReference.UserDTO GetUserById(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserById", ReplyAction="http://tempuri.org/IUserService/GetUserByIdResponse")]
        System.Threading.Tasks.Task<UserServiceClientReference.UserDTO> GetUserByIdAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAllUsers", ReplyAction="http://tempuri.org/IUserService/GetAllUsersResponse")]
        UserServiceClientReference.UserDTO[] GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAllUsers", ReplyAction="http://tempuri.org/IUserService/GetAllUsersResponse")]
        System.Threading.Tasks.Task<UserServiceClientReference.UserDTO[]> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateUser", ReplyAction="http://tempuri.org/IUserService/UpdateUserResponse")]
        bool UpdateUser(UserServiceClientReference.UserDTO user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateUser", ReplyAction="http://tempuri.org/IUserService/UpdateUserResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserAsync(UserServiceClientReference.UserDTO user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        bool DeleteUser(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        System.Threading.Tasks.Task<bool> DeleteUserAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ResetPassword", ReplyAction="http://tempuri.org/IUserService/ResetPasswordResponse")]
        bool ResetPassword(int userId, string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ResetPassword", ReplyAction="http://tempuri.org/IUserService/ResetPasswordResponse")]
        System.Threading.Tasks.Task<bool> ResetPasswordAsync(int userId, string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByUsername", ReplyAction="http://tempuri.org/IUserService/GetUserByUsernameResponse")]
        UserServiceClientReference.UserDTO GetUserByUsername(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByUsername", ReplyAction="http://tempuri.org/IUserService/GetUserByUsernameResponse")]
        System.Threading.Tasks.Task<UserServiceClientReference.UserDTO> GetUserByUsernameAsync(string userName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IUserServiceChannel : UserServiceClientReference.IUserService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<UserServiceClientReference.IUserService>, UserServiceClientReference.IUserService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public UserServiceClient() : 
                base(UserServiceClient.GetDefaultBinding(), UserServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IUserService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UserServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(UserServiceClient.GetBindingForEndpoint(endpointConfiguration), UserServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UserServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(UserServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UserServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(UserServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public UserServiceClientReference.UserDTO Login(string username, string password)
        {
            return base.Channel.Login(username, password);
        }
        
        public System.Threading.Tasks.Task<UserServiceClientReference.UserDTO> LoginAsync(string username, string password)
        {
            return base.Channel.LoginAsync(username, password);
        }
        
        public UserServiceClientReference.UserDTO RegisterUser(UserServiceClientReference.UserDTO user)
        {
            return base.Channel.RegisterUser(user);
        }
        
        public System.Threading.Tasks.Task<UserServiceClientReference.UserDTO> RegisterUserAsync(UserServiceClientReference.UserDTO user)
        {
            return base.Channel.RegisterUserAsync(user);
        }
        
        public UserServiceClientReference.UserDTO GetUserById(int userId)
        {
            return base.Channel.GetUserById(userId);
        }
        
        public System.Threading.Tasks.Task<UserServiceClientReference.UserDTO> GetUserByIdAsync(int userId)
        {
            return base.Channel.GetUserByIdAsync(userId);
        }
        
        public UserServiceClientReference.UserDTO[] GetAllUsers()
        {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<UserServiceClientReference.UserDTO[]> GetAllUsersAsync()
        {
            return base.Channel.GetAllUsersAsync();
        }
        
        public bool UpdateUser(UserServiceClientReference.UserDTO user)
        {
            return base.Channel.UpdateUser(user);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUserAsync(UserServiceClientReference.UserDTO user)
        {
            return base.Channel.UpdateUserAsync(user);
        }
        
        public bool DeleteUser(int userId)
        {
            return base.Channel.DeleteUser(userId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteUserAsync(int userId)
        {
            return base.Channel.DeleteUserAsync(userId);
        }
        
        public bool ResetPassword(int userId, string newPassword)
        {
            return base.Channel.ResetPassword(userId, newPassword);
        }
        
        public System.Threading.Tasks.Task<bool> ResetPasswordAsync(int userId, string newPassword)
        {
            return base.Channel.ResetPasswordAsync(userId, newPassword);
        }
        
        public UserServiceClientReference.UserDTO GetUserByUsername(string userName)
        {
            return base.Channel.GetUserByUsername(userName);
        }
        
        public System.Threading.Tasks.Task<UserServiceClientReference.UserDTO> GetUserByUsernameAsync(string userName)
        {
            return base.Channel.GetUserByUsernameAsync(userName);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IUserService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IUserService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:50984/UserService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return UserServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IUserService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return UserServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IUserService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IUserService,
        }
    }
}
