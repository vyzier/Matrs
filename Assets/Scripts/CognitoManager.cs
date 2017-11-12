//
// Copyright 2014-2015 Amazon.com, 
// Inc. or its affiliates. All Rights Reserved.
// 
// Licensed under the AWS Mobile SDK For Unity 
// Sample Application License Agreement (the "License"). 
// You may not use this file except in compliance with the 
// License. A copy of the License is located 
// in the "license" file accompanying this file. This file is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, express or implied. See the License 
// for the specific language governing permissions and 
// limitations under the License.
//

//Add the Facebook Unity SDK and uncomment this to enable Facebook login
#define USE_FACEBOOK_LOGIN

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using Amazon;
using Amazon.CognitoSync;
using Amazon.Runtime;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;
using Amazon.CognitoSync.SyncManager;
using Facebook.Unity;

namespace AWSSDK.Examples
{

    public class CognitoManager : MonoBehaviour
    {

        public string IdentityPoolId = "";

        public string Region = RegionEndpoint.USEast1.SystemName;

        private RegionEndpoint _Region
        {
            get { return RegionEndpoint.GetBySystemName(Region); }
        }

        private CognitoAWSCredentials _credentials;

        private CognitoAWSCredentials Credentials
        {
            get
            {
                if (_credentials == null)
                    _credentials = new CognitoAWSCredentials(IdentityPoolId, _Region);
                return _credentials;
            }
        }


        private CognitoSyncManager _syncManager;

        private CognitoSyncManager SyncManager
        {
            get
            {
                if (_syncManager == null)
                {
                    _syncManager = new CognitoSyncManager(Credentials, new AmazonCognitoSyncConfig { RegionEndpoint = _Region });
                }
                return _syncManager;
            }
        }

        void Start()
        {
            UnityInitializer.AttachToGameObject(this.gameObject);
        }

    #region Public Authentication Providers
#if USE_FACEBOOK_LOGIN
        private void FacebookLoginCallback(IResult result)
        {
            Debug.Log("FB.Login completed");

            if (result.Error != null || !FB.IsLoggedIn)
            {
                Debug.LogError(result.Error);
            }
            else
            {
                Debug.Log(result.ToString());
                Credentials.AddLogin ("graph.facebook.com", FB.ClientToken);
            }
        }

#endif
    #endregion

        public void FacebookLogin()
        {
#if USE_FACEBOOK_LOGIN
            if (!FB.IsInitialized)
            {
                FB.Init(delegate ()
                {
                    Debug.Log("starting thread");

                    // shows to connect the current identityid or create a new identityid with facebook authentication
                    FB.LogInWithReadPermissions(new List<string>() { "email" }, FacebookLoginCallback);
                });
            }
            else
            {
                FB.LogInWithReadPermissions(new List<string>() { "email" }, FacebookLoginCallback);
            }
#endif
        }

        public void AmazonLogin()
        {
            
        }
    }
}
